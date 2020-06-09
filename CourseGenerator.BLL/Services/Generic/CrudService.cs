using AutoMapper;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services.Generic
{
    public class CrudService<TEntity, TDTO>
        : ICrudService<TEntity, TDTO>
        where TEntity : class
        where TDTO : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected readonly IRepository<TEntity> _repository;


        public CrudService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;

            _repository = _uow.GetRepository<TEntity, IRepository<TEntity>>() 
                as IRepository<TEntity>;
        }

        public virtual async Task<OperationInfo> CreateAsync(string userId,
            TDTO dto)
        {
            if (dto == null)
                return new OperationInfo(false, "DTO is null");

            try
            {
                TEntity entity = _mapper.Map<TEntity>(dto);

                await _repository.CreateAsync(entity);
                await _uow.SaveAsync();

                return new OperationInfo(true, $"{typeof(TEntity).Name} was " +
                    $"created successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        public virtual async Task<TDTO> GetAsync(string userId,
            params object[] id)
        {
            TEntity entity = await _repository.GetAsync(id);
            return _mapper.Map<TDTO>(entity);
        }

        public virtual async Task<OperationInfo> UpdateAsync(string userId,
            TDTO dto)
        {
            if (dto == null)
                return new OperationInfo(false, "DTO is null");

            try
            {
                TEntity entity = _mapper.Map<TEntity>(dto);

                _repository.Update(entity);
                await _uow.SaveAsync();

                return new OperationInfo(true, $"{typeof(TEntity).Name} was " +
                    $"updated successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        public virtual async Task<OperationInfo> DeleteAsync(string userId,
            params object[] id)
        {
            try
            {
                TEntity entity = await _repository.GetAsync(id);

                _repository.Delete(entity);
                await _uow.SaveAsync();

                return new OperationInfo(true, $"{typeof(TEntity).Name} was " +
                    $"deleted successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        public virtual void Dispose() => _uow.Dispose();
    }
}
