using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
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

        public async Task<bool?> GetIsCompletedOrNullByThemeIdAsync(
            string userId, int themeId)
        {
            UserTheme theme = await _context.UserThemes
                .FirstOrDefaultAsync(ut => ut.UserId == userId &&
                                     ut.ThemeId == themeId);
            return theme?.IsCompleted;
        }

        public async Task<IEnumerable<ThemeLang>> GetLocalizedThemesByCourseIdAsync(
            string langCode, int courseId, int LevelNumber)
        {
            IQueryable<int> courseThemes = _context.Themes
                .Where(t => t.CourseId == courseId)
                .Where(t => t.ParentId == null)
                .Where(t => t.LevelNumber == LevelNumber)
                .Select(t => t.Id);

            IQueryable<ThemeLang> themesWithSpecifiedLang = _context.ThemeLangs
                .Include(tl => tl.Lang)
                .Where(tl => courseThemes.Contains(tl.ThemeId))
                .Where(tl => tl.Lang.Code == langCode);

            IQueryable<ThemeLang> themesWithFirstLang = _context.ThemeLangs
                .Include(tl => tl.Lang)
                .Where(tl => courseThemes.Contains(tl.ThemeId))
                .Where(tl => !themesWithSpecifiedLang
                              .Select(tl => tl.ThemeId)
                              .Contains(tl.ThemeId));

            IQueryable<ThemeLang> courseThemesWithLang = themesWithSpecifiedLang.Union(themesWithFirstLang);

            return await courseThemesWithLang.ToListAsync();
        }

        public async Task<IEnumerable<ThemeLang>> GetChildrenLocalAsync(
            int parentId, string langCode)
        {
            IEnumerable<Theme> themes = _context.Themes
                .Include(p => p.Themes)
                .FirstOrDefault(t => t.Id == parentId)
                ?.Themes
                .Where(t => t.ParentId == parentId);

            if (themes == null)
                return null;

            IQueryable<ThemeLang> themesWithSpecifiedLang = _context.ThemeLangs
                .Include(p => p.Lang)
                .Include(p => p.Theme)
                .Where(tl => themes.Contains(tl.Theme))
                .Where(tl => tl.LangCode == langCode);

            IQueryable<ThemeLang> themesWithFirstLang = _context.ThemeLangs
                .Include(tl => tl.Lang)
                .Include(tl => tl.Theme)
                .Where(tl => themes.Contains(tl.Theme)) //
                .Where(tl => !themesWithSpecifiedLang
                              .Select(tl => tl.ThemeId)
                              .Contains(tl.ThemeId));

            IQueryable<ThemeLang> themeLangs = themesWithSpecifiedLang.Union(themesWithFirstLang);

            return await themeLangs.ToListAsync();
        }

        public async Task<IEnumerable<ThemeLang>> GetThemeCoursesAsync(int courseId, string langCode)
        {
            IQueryable<ThemeLang> themeLangs = _context.ThemeLangs
                .Include(tl => tl.Theme)
                .Where(tl => tl.LangCode == langCode && tl.Theme.CourseId == courseId);

            if(themeLangs == null)
                return await _context.ThemeLangs
                    .Include(tl => tl.Theme)
                    .Where(tl => tl.Theme.CourseId == courseId).ToListAsync();

            return await themeLangs.ToListAsync();
        }
    }
}
