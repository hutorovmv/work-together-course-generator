using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Extensions;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Pagination;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        
        public CourseService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<OperationInfo> AddUserToCourseAsync(string userId, 
            int courseId, int levelId)
        {
            try
            {
                await _uow.UserCourseRepository.CreateAsync(new UserCourse
                {
                    UserId = userId,
                    CourseId = courseId,
                    LevelId = levelId
                });
                await _uow.SaveAsync();

                return new OperationInfo(true, "User was added to course successfully");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, $"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CourseSelectDTO>> GetUserCoursesLocalizedAsync(string userId, 
            string langCode)
        {
            IEnumerable<CourseLang> userCoursesLocalized = await _uow.CourseRepository
                .GetForUserWithLangAsync(userId, langCode);

            return _mapper.Map<IEnumerable<CourseSelectDTO>>(userCoursesLocalized);
        }

        public async Task<int?> GetLastThemeIdOrNullAsync(string userId, int courseId)
        {
            return await _uow.CourseRepository.GetLastThemeIdOrNullAsync(userId, courseId);
        }

        public async Task<IEnumerable<ThemeSelectDTO>> GetUserCourseThemesLocalizedAsync(string userId, 
            int courseId, int levelId, string langCode)
        {
            IEnumerable<ThemeLang> userCourseThemeLangs = await _uow.ThemeRepository
                .GetLocalizedThemesByCourseIdAsync(langCode, courseId, levelId);

            return await CreateThemeSelectDtos(userId, userCourseThemeLangs);
        }

        public async Task<IEnumerable<ThemeSelectDTO>> GetChildrenLocalAsync(string userId, int themeId, 
            string langCode)
        {
            IEnumerable<ThemeLang> themeLangs = await _uow.ThemeRepository
                .GetChildrenLocalAsync(themeId, langCode);

            return await CreateThemeSelectDtos(userId, themeLangs);
        }

        private async Task<IEnumerable<ThemeSelectDTO>> CreateThemeSelectDtos(string userId, 
            IEnumerable<ThemeLang> themeLangs)
        {
            IEnumerable<ThemeSelectDTO> themeSelectDtos = _mapper
                .Map<IEnumerable<ThemeSelectDTO>>(themeLangs);

            foreach (ThemeSelectDTO themeLang in themeSelectDtos)
            {
                themeLang.IsCompleted = await _uow.ThemeRepository
                    .GetIsCompletedOrNullByThemeIdAsync(userId, themeLang.Id) ?? false;
            }

            return themeSelectDtos;
        }

        public void Dispose() => _uow.Dispose();
    }
}
