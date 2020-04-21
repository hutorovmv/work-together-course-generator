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

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseSelectDTO>> GetCoursesForUserWithLang(string langCode)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<CourseSelectDTO> courseSelectDTOs = await _courseService
                .GetUserCoursesLocalizedAsync(userId, langCode);

            return courseSelectDTOs;
        }

        [Route("~/api/[controller]/themes/parent")]
        [HttpGet]
        public async Task<IActionResult> GetUserCourseThemesWithLevelLocalized(int courseId, 
            int levelId, string langCode)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int? lastThemeId = await _courseService.GetLastThemeIdOrNullAsync(userId, courseId);
            if (lastThemeId != null)
                return RedirectToAction(""); // TODO: specify appropriate action name

            IEnumerable<ThemeSelectDTO> themeSelectDtos = await _courseService
                .GetUserCourseThemesLocalizedAsync(userId, courseId, levelId, langCode);

            return Ok(themeSelectDtos);
        }
    }
}