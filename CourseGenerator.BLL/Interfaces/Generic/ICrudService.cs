using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    /// <summary>
    /// Узагальнений CRUD сервіс
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDTO"></typeparam>
    public interface ICrudService<out TEntity, TDTO>
        : IDisposable
        where TEntity : class
        where TDTO : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">Користувач, від імені якого виконується
        /// дія</param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationInfo> CreateAsync(string userId, TDTO dto);
        Task<TDTO> GetAsync(string userId, params object[] id);
        Task<OperationInfo> UpdateAsync(string userId, TDTO dto);
        Task<OperationInfo> DeleteAsync(string userId, params object[] id);
    }
}
