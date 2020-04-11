using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IThemeRepository: IGenericEFRepository<Theme>
    {
        Task<bool?> GetIsCompletedOrNullByThemeIdAsync(string userId, int themeId);

        Task<IEnumerable<ThemeLang>> GetLocalizedThemesByIdAsync(
            int themeId, string langCode, int courseId);

        IEnumerable<Theme> GetChildThemesOrNullById(int themeId);
    }
}
