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
        Task<OperationInfo> AddUserToCourseAsync(string userId, int courseId, int levelId);
        Task<IEnumerable<CourseSelectDTO>> GetUserCoursesLocalizedAsync(string userId,
            string langCode);
    }
}
