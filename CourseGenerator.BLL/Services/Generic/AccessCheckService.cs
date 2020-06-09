using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services.Generic
{
    public class AccessCheckService<TAccessEntity>
        : IAccessCheckService<TAccessEntity>
        where TAccessEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IAccessManager<TAccessEntity> _accessManager;

        public AccessCheckService(IUnitOfWork uow)
        {
            _uow = uow;
            _accessManager = _uow.GetRepository<TAccessEntity, 
                IAccessManager<TAccessEntity>>() as IAccessManager<TAccessEntity>;
        }

        public virtual async Task<OperationInfo> HasCreateAccess(string userId)
        {
            bool hasAccess = await _uow.UserManager.IsContentAdmin(userId);
            
            if (!hasAccess)
                return new OperationInfo(false, $"Not permitted");

            return new OperationInfo(true, "Access granted");
        }

        public virtual async Task<OperationInfo> HasGetAccess(string userId)
        {
            bool hasAccess = await _uow.UserManager.IsContentAdmin(userId)
                || _accessManager.HasAccess(userId);
            
            if (!hasAccess)
                return new OperationInfo(false, $"Not permitted");

            return new OperationInfo(true, "Access granted");
        }

        public virtual async Task<OperationInfo> HasUpdateAccess(string userId)
        {
            bool hasAccess = await _uow.UserManager.IsContentAdmin(userId);

            if (!hasAccess)
                return new OperationInfo(false, $"Not permitted");

            return new OperationInfo(true, "Access granted");
        }

        public virtual async Task<OperationInfo> HasDeleteAccess(string userId)
        {
            bool hasAccess = await _uow.UserManager.IsContentAdmin(userId);

            if (!hasAccess)
                return new OperationInfo(false, $"Not permitted");

            return new OperationInfo(true, "Access granted");
        }

        public virtual async Task<OperationInfo> HasHierarchyAccess(
            string userId)
        {
            bool hasAccess = await _uow.UserManager.IsContentAdmin(userId)
                || _accessManager.HasAccess(userId);

            if (!hasAccess)
                return new OperationInfo(false, $"Not permitted");

            return new OperationInfo(true, "Access granted");
        }

        public virtual void Dispose() => _uow.Dispose();
    }
}