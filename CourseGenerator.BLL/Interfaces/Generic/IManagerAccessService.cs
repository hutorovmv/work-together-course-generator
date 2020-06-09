using CourseGenerator.BLL.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    public interface IManagerAccessService<out TAccessEntity, TAccessDTO> 
        : ICrudService<TAccessEntity, TAccessDTO>, IDisposable
        where TAccessEntity : class
        where TAccessDTO : class
    {
        Task<OperationInfo> CreateManagerAsync(string userId, TAccessDTO dto);
        Task<TAccessDTO> GetManagerAsync(string userId, params object[] id);
        Task<OperationInfo> UpdateManagerAsync(string userId, TAccessDTO dto);
        Task<OperationInfo> DeleteManagerAsync(string userId, params object[] id);
    }
}
