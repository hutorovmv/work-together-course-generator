using System;
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
        Task<OperationInfo> UserNameNotExistsAsync(string userName);
        Task<OperationInfo> AddToRolesAsync(User user, params string[] roles);
        Task<UserDetailsDTO> GetDetailsByNameAsync(string userName);
        Task<ClaimsIdentity> GetIdentityAsync(UserLoginDTO userLoginDto);
        Task<ClaimsIdentity> GetIdentityAsync(PhoneAuthDTO phoneAuthDto);
        Task<ClaimsIdentity> GetIdentityAsync(CodeAuthDTO codeAuthDto);
        Task<OperationInfo> ConfirmPhoneAsync(string userName);
        Task<OperationInfo> SaveConfirmCodeAsync(PhoneAuthDTO phoneAuthDto);
        Task<OperationInfo> SaveConfirmCodeAsync(CodeAuthDTO codeAuthDto);
    }
}
