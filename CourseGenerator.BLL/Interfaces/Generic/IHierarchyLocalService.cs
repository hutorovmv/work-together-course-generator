using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces.Generic
{
    public interface IHierarchyLocalService<TId, out TEntityLocal, TDTOHierarchy> 
        : IDisposable
        where TEntityLocal : class
        where TDTOHierarchy : class // DTO should contain code for hierarchy
    {
        Task<IEnumerable<TDTOHierarchy>> GetRootLocalAsync(string userId, 
            string langCode);
        Task<IEnumerable<TDTOHierarchy>> GetParentsLocalAsync(string userId, 
            string langCode, TId id);
        Task<IEnumerable<TDTOHierarchy>> GetChildrenLocalAsync(string userId, 
            string langCode, TId id);
    }
}
