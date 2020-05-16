using System;
using System.Threading.Tasks;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using System.Security.Claims;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.User;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IUserManagementService : IDisposable
    {
        /// <summary>
        /// Створює користувача.
        /// </summary>
        /// <param name="registrationDto">дані користувача</param>
        /// <returns>Дані про успішність реєстрації.</returns>
        Task<OperationInfo> CreateAsync(RegisterDTO registrationDto, 
            params string[] roles);

        /// <summary>
        /// Перевіряє чи існує користувач за іменем користувача.
        /// </summary>
        /// <param name="username">ім'я користувача</param>
        /// <returns><see cref="OperationInfo.Succeeded"/> <c>true</c> коли 
        /// такий користувач не існує та <c>false</c> - коли існує.</returns>
        Task<OperationInfo> UserNameNotExistsAsync(string userName);

        /// <summary>
        /// Додає користувача до ролей.
        /// </summary>
        /// <param name="user">користувач</param>
        /// <param name="role">роль</param>
        /// <returns><see cref="OperationInfo.Succeeded"> - <c>true</c>, коли 
        /// користувач успішно доданий до ролей та <c>false</c> - коли ні.
        /// </returns>
        Task<OperationInfo> AddToRolesAsync(User user, params string[] roles);

        /// <summary>
        /// Отримує детальні дані про користувача.
        /// </summary>
        /// <param name="userName">ім'я користувача</param>
        /// <returns>DTO, що містить детальну інформацію про користувача.
        /// </returns>
        Task<UserDetailsDTO> GetDetailsByNameAsync(string userName);

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> з клеймами користувача
        /// з таким іменем користувача та паролем.
        /// </summary>
        /// <param name="code">Унікальний код для аутентифікації</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.
        /// </returns>
        Task<ClaimsIdentity> GetIdentityAsync(LoginDTO userLoginDto);

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> з клеймами користувача
        /// з таким іменем користувача та паролем.
        /// </summary>
        /// <param name="phoneAuthDto">DTO, що містить номер телефону та 
        /// код</param>
        /// <param name="password">пароль</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.
        /// </returns>
        Task<ClaimsIdentity> GetIdentityAsync(PhoneAuthDTO phoneAuthDto);

        /// <summary>
        /// Створює <see cref="ClaimsIdentity"/> для користувача, по даному
        /// унікальному коду.</summary>
        /// <param name="code">унікальний код</param>
        /// <returns><see cref="ClaimsIdentity"/> з клеймами користувача.
        /// </returns>
        Task<ClaimsIdentity> GetIdentityAsync(string code);

        /// <summary>
        /// Встановлює значення <c>true</c> для 
        /// <see cref="User.PhoneNumberConfirmed" />.
        /// </summary>
        /// <param name="userName">ім'я користувача</param>
        /// <returns><see cref="OperationInfo.Succeeded"/> - <c>true</c>, коли 
        ///  номер телефону успішно підтверджено та <c>false</c> - коли ні.
        ///  </returns>
        Task<OperationInfo> ConfirmPhoneAsync(string userName);

        
        /// <summary>
        /// Зберігає одноразовий код підтвердження 
        /// для аутентифікації користувача.
        /// </summary>
        /// <param name="phoneAuthDto">DTO, який містить номер телефону та 
        /// код</param>
        /// <returns>Інформацію про виконання операції</returns>
        Task<OperationInfo> SaveConfirmCodeAsync(PhoneAuthDTO phoneAuthDto);

        /// <summary>
        /// Зберігає одноразовий код підтвердження 
        /// для аутентифікації користувача.
        /// </summary>
        /// <param name="codeAuthDto">DTO, який містить ідентифікатор 
        /// користувача та унікальний код для аутентифікації</param>
        /// <returns>Інформацію про виконання операції</returns>
        Task<OperationInfo> SaveConfirmCodeAsync(CodeAuthDTO codeAuthDto);
    }
}
