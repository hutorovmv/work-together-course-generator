using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using System.Security.Claims;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.BLL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserManagementService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <summary>
        /// Створює користувача.
        /// </summary>
        /// <param name="registrationDto">дані користувача</param>
        /// <returns>Дані про успішність реєстрації.</returns>
        public async Task<OperationInfo> CreateAsync(UserRegistrationDTO registrationDto,
            params string[] roles)
        {
            // Email використовується в якості імені користувача
            OperationInfo userExistsResult = await UserNameNotExistsAsync(
                registrationDto.Email);
            if (!userExistsResult.Succeeded)
                return userExistsResult;

            // Створює об'єкт та генерує значення для стрічкової властивості Id
            User user = new User();
            user = _mapper.Map<User>(registrationDto);

            IdentityResult createResult = await _uow.UserManager
                .CreateAsync(user, registrationDto.Password);
            if (createResult.Errors.Count() > 0)
                return new OperationInfo(false, createResult.Errors.FirstOrDefault()
                    ?.Description);

            OperationInfo userHaveRole = await AddToRolesAsync(user, roles);
            if (!userHaveRole.Succeeded)
                return userHaveRole;

            return new OperationInfo(true, "User created successfuly");
        }

        /// <summary>
        /// Перевіряє чи існує користувач за іменем користувача.
        /// </summary>
        /// <param name="username">ім'я користувача</param>
        /// <returns><see cref="OperationInfo.Succeeded"/> <c>true</c> коли такий 
        /// користувач не існує та <c>false</c> - коли існує.</returns>
        public async Task<OperationInfo> UserNameNotExistsAsync(string userName)
        {
            User user = await _uow.UserManager.FindByNameAsync(userName);
            if (user != null)
                return new OperationInfo(false, $"User with username = {userName} exists");

            return new OperationInfo(true, "There is no user with such username");
        }

        /// <summary>
        /// Додає користувача до ролей.
        /// </summary>
        /// <param name="user">користувач</param>
        /// <param name="role">роль</param>
        /// <returns><see cref="OperationInfo.Succeeded"> - <c>true</c>, коли 
        /// користувач успішно доданий до ролей та <c>false</c> - коли ні.</returns>
        public async Task<OperationInfo> AddToRolesAsync(User user, params string[] roles)
        {
            IdentityResult result = await _uow.UserManager.AddToRolesAsync(user, roles);
            if (result.Errors.Count() > 0)
                return new OperationInfo(false, result.Errors.FirstOrDefault().Description);
                
            return new OperationInfo(true, "Roles was successfully given to user");
        }

        /// <summary>
        /// Встановлює значення <c>true</c> для <see cref="User.PhoneNumberConfirmed" />.
        /// </summary>
        /// <param name="userName">ім'я користувача</param>
        /// <returns><see cref="OperationInfo.Succeeded"/> - <c>true</c>, коли 
        ///  номер телефону успішно підтверджено та <c>false</c> - коли ні.</returns>
        public async Task<OperationInfo> ConfirmPhoneAsync(string userName)
        {
            User user = await _uow.UserManager.FindByNameAsync(userName);

            if (user.PhoneNumberConfirmed == false)
            {
                try
                {
                    user.PhoneNumberConfirmed = true;
                    await _uow.UserManager.UpdateAsync(user);
                    await _uow.SaveAsync();
                    return new OperationInfo(true, "Phone number is confirmed " +
                        "successfully");
                }
                catch(Exception ex)
                {
                    return new OperationInfo(false, ex.Message);
                }
            }

            return new OperationInfo(false, "Phone number is already confirmed");
        }

        /// <summary>
        /// Отримує детальні дані про користувача.
        /// </summary>
        /// <param name="userName">ім'я користувача</param>
        /// <returns>DTO, що містить детальну інформацію про користувача.</returns>
        public async Task<UserDetailsDTO> GetDetailsByNameAsync(string userName)
        {
            User user = await _uow.UserManager.FindByNameAsync(userName);
            return _mapper.Map<UserDetailsDTO>(user);
        }

        public void Dispose() => _uow.Dispose();

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> для вказаного 
        /// користувача.
        /// </summary>
        /// <param name="user">Користувач</param>
        /// <returns><see cref="ClaimsIdentity"/> для даного користувача</returns>
        private async Task<ClaimsIdentity> GetIdentityAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Locality, user.PreferedLangCode)
            };

            IList<string> roles = await _uow.UserManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimsIdentity
                .DefaultRoleClaimType, r)));

            ClaimsIdentity identity = new ClaimsIdentity(claims, 
                "Token", 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            return identity;
        }

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> з клеймами користувача
        /// з таким іменем користувача та паролем.
        /// </summary>
        /// <param name="username">ім'я користувача</param>
        /// <param name="password">пароль</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.</returns>
        public async Task<ClaimsIdentity> GetIdentityAsync(UserLoginDTO userLoginDto)
        {
            User user = await _uow.UserManager.FindByNameAsync(userLoginDto.UserName);
            if (user == null)
                return null;

            bool isPasswordValid = await _uow.UserManager
                .CheckPasswordAsync(user, userLoginDto.Password);
            if (!isPasswordValid)
                return null;

            return await GetIdentityAsync(user);
        }

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> з клеймами користувача
        /// з таким номером телефону та кодом.
        /// </summary>
        /// <param name="phoneAuthDto">DTO, що містить номер телефону та код для 
        /// аутентифікації</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.</returns>
        public async Task<ClaimsIdentity> GetIdentityAsync(PhoneAuthDTO phoneAuthDto)
        {
            PhoneAuth phoneAuth = await _uow.PhoneAuthRepository
                .GetAsync(phoneAuthDto.PhoneNumber, phoneAuthDto.Code);
            if (phoneAuth == null)
                return null;

            try
            {
                _uow.PhoneAuthRepository.Delete(phoneAuth);
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            User user = await _uow.UserManager
                .FindByPhoneNumberAsync(phoneAuth.PhoneNumber);
            return await GetIdentityAsync(user);
        }

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> з клеймами користувача
        /// з таким іменем користувача та паролем.
        /// </summary>
        /// <param name="codeAuthDto">DTO, що містить Id користувача та унікальний
        /// код для аутентифікації</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.</returns>
        public async Task<ClaimsIdentity> GetIdentityAsync(CodeAuthDTO codeAuthDto)
        {
            CodeAuth codeAuth = await _uow.CodeAuthRepository
                .GetAsync(codeAuthDto.UserId, codeAuthDto.Code);
            if (codeAuth == null)
                return null;

            try
            {
                _uow.CodeAuthRepository.Delete(codeAuth);
                await _uow.SaveAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            User user = await _uow.UserManager.FindByIdAsync(codeAuth.UserId);
            return await GetIdentityAsync(user);
        }

        /// <summary>
        /// Зберігає одноразовий код підтвердження 
        /// для аутентифікації користувача.
        /// </summary>
        /// <param name="phoneAuthDto">DTO, який містить номер телефону та код</param>
        /// <returns>Інформацію про виконання операції</returns>
        public async Task<OperationInfo> SaveConfirmCodeAsync(PhoneAuthDTO phoneAuthDto)
        {
            try
            {
                PhoneAuth phoneAuth = await _uow.PhoneAuthRepository
                    .GetAsync(phoneAuthDto.PhoneNumber);          

                if (phoneAuth != null)
                {
                    _uow.PhoneAuthRepository.Delete(phoneAuth);
                    await _uow.SaveAsync();
                }

                phoneAuth = _mapper.Map<PhoneAuth>(phoneAuthDto);
                await _uow.PhoneAuthRepository.CreateAsync(phoneAuth);
                await _uow.SaveAsync();
                
                return new OperationInfo(true, "Phone number confirmation code was " +
                    "added successfully.");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        /// <summary>
        /// Зберігає унікальний одноразовий код підтвердження 
        /// для аутентифікації користувача.
        /// </summary>
        /// <param name="codeAuthDto">DTO, який містить Id користувача та код</param>
        /// <returns>Інформацію про виконання операції</returns>
        public async Task<OperationInfo> SaveConfirmCodeAsync(CodeAuthDTO codeAuthDto)
        {
            try
            {
                CodeAuth codeAuth = await _uow.CodeAuthRepository
                    .GetAsync(codeAuthDto.UserId);

                if (codeAuth != null)
                {
                    _uow.CodeAuthRepository.Delete(codeAuth);
                    await _uow.SaveAsync();
                }

                codeAuth = _mapper.Map<CodeAuth>(codeAuthDto);
                await _uow.CodeAuthRepository.CreateAsync(codeAuth);
                await _uow.SaveAsync();

                return new OperationInfo(true, "Confirmation code was added successfully.");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }
    }
}
