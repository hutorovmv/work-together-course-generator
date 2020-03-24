using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.BLL.Services
{
    public class UserManagementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserManagementService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="registrationDto">Data from client</param>
        /// <returns>Information about registration</returns>
        public async Task<OperationInfo> CreateAsync(UserRegistrationDTO registrationDto)
        {
            // Email is used as username
            OperationInfo userExistsResult = await ExistsWithUserNameAsync(registrationDto.Email);
            if (!userExistsResult.Succeeded)
                return userExistsResult;

            // Creates user object and generates string for Id property
            User user = new User();
            user = _mapper.Map<User>(registrationDto);

            IdentityResult result = await _uow.UserManager.CreateAsync(user, registrationDto.Password);
            if (result.Errors.Count() > 0)
                return new OperationInfo(false, result.Errors.FirstOrDefault()?.Description);

            OperationInfo userHaveRole = await AddToRoleAsync(user, "User");
            if (!userHaveRole.Succeeded)
                return userHaveRole;

            return new OperationInfo(true, "User created successfuly");
        }

        /// <summary>
        /// Checks if user exists
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>Succeeds when user exists and fails when not</returns>
        private async Task<OperationInfo> ExistsWithUserNameAsync(string username)
        {
            User user = await _uow.UserManager.FindByNameAsync(username);
            if (user != null)
                return new OperationInfo(true, "User with such username exists");
            else
                return new OperationInfo(false, "There is no user with such username");
        }

        /// <summary>
        /// Adds user to role
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="role">Role</param>
        /// <returns>Whether role was given to user of not</returns>
        private async Task<OperationInfo> AddToRoleAsync(User user, string role)
        {
            IdentityResult result = await _uow.UserManager.AddToRoleAsync(user, role);
            if (result.Errors.Count() > 0)
                return new OperationInfo(true, "Role was successfully given to user");
            else
                return new OperationInfo(false, result.Errors.FirstOrDefault()?.Description);
        }
    }
}
