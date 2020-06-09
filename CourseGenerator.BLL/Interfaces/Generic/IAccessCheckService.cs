using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    public interface IAccessCheckService<TAccessEntity> : IDisposable
        where TAccessEntity : class
    {
        Task<OperationInfo> HasCreateAccess(string userId);
        Task<OperationInfo> HasGetAccess(string userId);
        Task<OperationInfo> HasUpdateAccess(string userId);
        Task<OperationInfo> HasDeleteAccess(string userId);
        Task<OperationInfo> HasHierarchyAccess(string userId);
    }
}
