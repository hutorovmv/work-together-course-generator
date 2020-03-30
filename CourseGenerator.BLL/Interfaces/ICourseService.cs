using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.DAL.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface ICourseService : IDisposable
    {
        Task<PagedList<CourseItemDTO>> GetByPhoneWithLangPagedAsync(
            string userPhoneNumber, string langCode, int pageSize, int pageIndex);

        Task<OperationInfo> AddUserToCourseAsync(string userId, int courseId, int levelId);
    }
}
