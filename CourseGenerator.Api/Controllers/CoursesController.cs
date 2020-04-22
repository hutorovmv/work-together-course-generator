using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGenerator.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly string userId;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
            userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IEnumerable<CourseSelectDTO>> GetUserCoursesLocalAsync(string langCode)
        {
            IEnumerable<CourseSelectDTO> courseSelectDTOs = await _courseService
                .GetUserCoursesLocalizedAsync(userId, langCode);

            return courseSelectDTOs;
        }

        [Route("~/api/[controller]/levels")]
        [HttpGet]
        public async Task<IEnumerable<LevelSelectDTO>> GetCourseLevelsLocalAsync(int courseId, 
            string langCode)
        {
            return await _courseService.GetCourseLevelsLocalAsync(courseId, langCode);
        }

        [Route("~/api/[controller]/themes/children")]
        [HttpGet]
        public async Task<IActionResult> GetUserCourseThemeChildrenAsync(int themeId, 
            string langCode)
        {
            IEnumerable<ThemeSelectDTO> childThemes = await _courseService
                .GetChildrenLocalAsync(userId, themeId, langCode);

            if (childThemes == null)
                return RedirectToAction(""); // TODO: specify appropriate action name

            return Ok(childThemes);
        }

        [Route("~/api/[controller]/themes/parent")]
        [HttpGet]
        public async Task<IActionResult> GetUserCourseThemesLocalAsync(int courseId, 
            int levelId, string langCode)
        {
            int? lastThemeId = await _courseService.GetLastThemeIdOrNullAsync(userId, courseId);
            if (lastThemeId != null)
                return RedirectToAction(""); // TODO: specify appropriate action name

            IEnumerable<ThemeSelectDTO> themeSelectDtos = await _courseService
                .GetUserCourseThemesLocalizedAsync(userId, courseId, levelId, langCode);

            return Ok(themeSelectDtos);
        }
    }
}