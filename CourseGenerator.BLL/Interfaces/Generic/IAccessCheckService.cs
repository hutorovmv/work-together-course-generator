using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    public interface IAccessCheckService<TAccessEntity> : IDisposable
        where TAccessEntity : class
    {
        Task<OperationInfo> HasCreateAccess(string userId, params object[] id);
        Task<OperationInfo> HasGetAccess(string userId, params object[] id);
        Task<OperationInfo> HasUpdateAccess(string userId, params object[] id);
        Task<OperationInfo> HasDeleteAccess(string userId, params object[] id);
    }
}
