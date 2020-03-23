using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseGenerator.DAL.Pagination;
using CourseGenerator.DAL.Context;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IGenericEFRepository<T> : IDisposable, IRepository<T> where T : class
    {
        IQueryable<T> GetAllQueryable();
        Task<PagedList<T>> GetPagedAsync(int pageSize, int pageIndex);
    }
}
