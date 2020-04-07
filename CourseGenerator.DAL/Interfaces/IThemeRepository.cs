using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IThemeRepository: IGenericEFRepository<Theme>
    {
        Task<bool?> GetIsCompletedByThemeId(string userId, int themeId);
    }
}
