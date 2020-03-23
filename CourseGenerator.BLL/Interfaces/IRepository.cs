using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(params object[] key);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T item);
        void Update(T item);
        void Delete(T item);
    }
}
