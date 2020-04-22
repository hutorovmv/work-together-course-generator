using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IThemeRepository : IRepository<Theme>
    {
        Task<bool?> GetIsCompletedOrNullByThemeIdAsync(string userId, int themeId);

        Task<IEnumerable<ThemeLang>> GetLocalizedThemesByCourseIdAsync( // GetByCourseLocalAsync
            string langCode, int courseId, int levelId);

        Task<IEnumerable<ThemeLang>> GetChildrenLocalAsync(int parentId, string levelCode);
    }
}
