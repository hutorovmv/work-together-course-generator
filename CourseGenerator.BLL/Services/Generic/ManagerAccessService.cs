using AutoMapper;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services.Generic
{
    public class ManagerAccessService<TAccessEntity, TAccessDTO>
        : IManagerAccessService<TAccessEntity, TAccessDTO>
        where TAccessEntity : class
        where TAccessDTO : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected readonly ICrudService<TAccessEntity, TAccessDTO>
            _accessCrudService;

        public ManagerAccessService(IUnitOfWork uow, IMapper mapper,
            ICrudService<TAccessEntity, TAccessDTO> accessCrudService)
        {
            _uow = uow;
            _mapper = mapper;

            _accessCrudService = accessCrudService;
        }

        public virtual async Task<OperationInfo> CreateManagerAsync(
            string userId, TAccessDTO dto)
        {
            return await _accessCrudService.CreateAsync(userId, dto);
        }

        public virtual async Task<TAccessDTO> GetManagerAsync(
            string userId, params object[] id)
        {
            return await _accessCrudService.GetAsync(userId, id);
        }

        public virtual async Task<OperationInfo> UpdateManagerAsync(
            string userId, TAccessDTO dto)
        {
            return await _accessCrudService.UpdateAsync(userId, dto);
        }

        public virtual async Task<OperationInfo> DeleteManagerAsync(
            string userId, params object[] id)
        {
            return await _accessCrudService.DeleteAsync(userId, id);
        }



        async Task<OperationInfo> ICrudService<TAccessEntity, TAccessDTO>
            .CreateAsync(string userId, TAccessDTO dto)
        {
            return await CreateManagerAsync(userId, dto);
        }

        async Task<TAccessDTO> ICrudService<TAccessEntity, TAccessDTO>
            .GetAsync(string userId, params object[] id)
        {
            return await GetManagerAsync(userId, id);
        }

        async Task<OperationInfo> ICrudService<TAccessEntity, TAccessDTO>
            .UpdateAsync(string userId, TAccessDTO dto)
        {
            return await UpdateManagerAsync(userId, dto);
        }

        async Task<OperationInfo> ICrudService<TAccessEntity, TAccessDTO>
            .DeleteAsync(string userId, params object[] id)
        {
            return await DeleteManagerAsync(userId, id);
        }



        public virtual void Dispose() => _uow.Dispose();
    }
}
