using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using System.Security.Claims;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IUserManagementService : IDisposable
    {
        Task<OperationInfo> CreateAsync(UserRegistrationDTO registrationDto, params string[] roles);
        Task<OperationInfo> ExistsWithUserNameAsync(string userName);
        Task<OperationInfo> AddToRolesAsync(User user, params string[] roles);
        Task<UserDetailsDTO> GetDetailsByUserNameAsync(string userName);
        Task<ClaimsIdentity> GetIdentityAsync(string username, string password);
        Task<OperationInfo> ConfirmPhoneNumberAsync(string userName);
    }
}
