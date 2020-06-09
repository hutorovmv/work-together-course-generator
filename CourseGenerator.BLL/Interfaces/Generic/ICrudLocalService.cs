using CourseGenerator.BLL.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    /// <summary>
    /// Адаптер для <see cref="ICrudService{TEntity, TDTO}"/>
    /// </summary>
    /// <typeparam name="TEntityLocal"></typeparam>
    /// <typeparam name="TDTOLocal"></typeparam>
    public interface ICrudLocalService<out TEntityLocal, 
        TDTOLocal> : IDisposable
        where TEntityLocal : class
        where TDTOLocal : class
    {
        Task<OperationInfo> CreateLocalAsync(string userId, TDTOLocal dto);
        Task<TDTOLocal> GetLocalAsync(string userId, string langCode, 
            params object[] id);
        Task<OperationInfo> UpdateLocalAsync(string userId, TDTOLocal dto);
        Task<OperationInfo> DeleteLocalAsync(string userId, string langCode, 
            params object[] id);
    }
}
