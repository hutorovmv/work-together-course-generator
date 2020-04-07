using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using CourseGenerator.DAL.Interfaces;

namespace CourseGenerator.DAL.Repositories
{
    public class ThemeRepository : GenericEFRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<bool?> GetIsCompletedByThemeId(
            string userId, int themeId)
        {
            UserTheme theme = await _context.UserThemes
                .FirstOrDefaultAsync(ut => ut.UserId == userId &&
                                     ut.ThemeId == themeId);
            return theme?.IsCompleted;
        }
    }
}
