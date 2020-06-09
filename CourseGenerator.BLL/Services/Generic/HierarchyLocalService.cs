using AutoMapper;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services.Generic
{
    public class HierarchyLocalService<TId, TEntityLocal, TDTOHierarchy>
        : IHierarchyLocalService<TId, TEntityLocal, TDTOHierarchy>
        where TEntityLocal : class
        where TDTOHierarchy : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected readonly IHierarchyLocal<TId, TEntityLocal>  _repository;

        public HierarchyLocalService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

            _repository = _uow.GetRepository<TEntityLocal, 
                IHierarchyLocal<TId, TEntityLocal>>() 
                as IHierarchyLocal<TId, TEntityLocal>;
        }

        public async Task<IEnumerable<TDTOHierarchy>> GetRootLocalAsync(
            string userId, string langCode)
        {
            IEnumerable<TEntityLocal> entities = await _repository
                .GetRootLocalAsync(langCode);
            return _mapper.Map<IEnumerable<TDTOHierarchy>>(entities);
        }

        public async Task<IEnumerable<TDTOHierarchy>> GetChildrenLocalAsync(
            string userId, string langCode, TId id)
        {
            IEnumerable<TEntityLocal> entities = await _repository
                .GetChildrenLocalAsync(id, langCode);
            return _mapper.Map<IEnumerable<TDTOHierarchy>>(entities);
        }

        public async Task<IEnumerable<TDTOHierarchy>> GetParentsLocalAsync(
            string userId, string langCode, TId id)
        {
            IEnumerable<TEntityLocal> entities = await _repository
                .GetParentsLocalAsync(id, langCode);
            return _mapper.Map<IEnumerable<TDTOHierarchy>>(entities);
        }

        public virtual void Dispose() => _uow.Dispose();
    }
}
