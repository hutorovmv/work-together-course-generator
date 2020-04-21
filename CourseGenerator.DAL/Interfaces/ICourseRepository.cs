using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseGenerator.DAL.Pagination;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<CourseLang>> GetForUserWithLangAsync(
            string userId, string langCode);

        Task<int?> GetLastThemeIdOrNullAsync(
            string userId, int courseId);

        Task<IEnumerable<Level>> GetLevelByCourseIdAsync(int courseId);

    }
}
