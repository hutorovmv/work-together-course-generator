using AutoMapper;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services.Generic
{
    public class CrudLocalService<TEntityLocal, TDTOLocal>
        : ICrudLocalService<TEntityLocal, TDTOLocal>
        where TEntityLocal : class
        where TDTOLocal : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected readonly ICrudService<TEntityLocal, TDTOLocal> 
            _localCrudService;

        public CrudLocalService(IUnitOfWork uow, IMapper mapper,
            ICrudService<TEntityLocal, TDTOLocal> localCrudService)
        {
            _uow = uow;
            _mapper = mapper;

            _localCrudService = localCrudService;
        }

        public virtual async Task<OperationInfo> CreateLocalAsync(string userId,
            TDTOLocal localDto)
        {
            return await _localCrudService.CreateAsync(userId, localDto);
        }

        public virtual async Task<TDTOLocal> GetLocalAsync(string userId,
            string langCode, params object[] id)
        {
            return await _localCrudService.GetAsync(userId,
                GeneratePK(langCode, id));
        }

        public virtual async Task<OperationInfo> UpdateLocalAsync(string userId,
            TDTOLocal localDto)
        {
            return await _localCrudService.UpdateAsync(userId, localDto);
        }

        public virtual async Task<OperationInfo> DeleteLocalAsync(string userId,
            string langCode, params object[] id)
        {
            return await _localCrudService
                .DeleteAsync(userId, GeneratePK(langCode, id));
        }

        protected virtual object[] GeneratePK(string langCode,
            params object[] id)
        {
            return id.Prepend(langCode).ToArray();
        }

        public virtual void Dispose() => _uow.Dispose();
    }
}
