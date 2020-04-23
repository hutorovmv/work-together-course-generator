using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер для роботи з даними про курсів
    /// </summary>
    [ApiController]
    [Authorize]
    [SwaggerTag("Контролер для роботи з даними про курсів")]
    [Produces(MediaTypeNames.Application.Json, new string[] { MediaTypeNames.Application.Xml })]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="courseService">Сервіс для роботи з курсами</param>
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Відображає курси, які доступні користувачу
        /// </summary>
        /// <param name="langCode">Код мови, якій надавати перевагу</param>
        /// <returns>Список курсів</returns>
        /// <response code="200">Операція виконана успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<CourseSelectDTO>> GetUserCoursesLocalAsync(string langCode)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<CourseSelectDTO> courseSelectDTOs = await _courseService
                .GetUserCoursesLocalizedAsync(userId, langCode);

            return courseSelectDTOs;
        }

        /// <summary>
        /// Отримує рівні складності тем, доступні в курсі
        /// </summary>
        /// <param name="courseId">Ідентифікатор курсу</param>
        /// <param name="langCode">Код мови, якій надавати перевагу</param>
        /// <returns>Доступні рівні складності тем</returns>
        /// <response code="200">Операція виконана успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [Route("~/api/[controller]/levels")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<LevelSelectDTO>> GetCourseLevelsLocalAsync(int courseId, 
            string langCode)
        {
            return await _courseService.GetCourseLevelsLocalAsync(courseId, langCode);
        }

        /// <summary>
        /// Підтеми для вказаної теми
        /// </summary>
        /// <param name="themeId">Ідентифікатор теми</param>
        /// <param name="langCode">Код мови, якій надавати перевагу</param>
        /// <returns>Список підтем</returns>
        /// <response code="200">Операція виконана успішно</response>
        /// <response code="302">Перенаправлення до матеріалу теми</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [Route("~/api/[controller]/themes/children")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<IActionResult> GetUserCourseThemeChildrenAsync(int themeId, 
            string langCode)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<ThemeSelectDTO> childThemes = await _courseService
                .GetChildrenLocalAsync(userId, themeId, langCode);

            if (childThemes == null)
                return RedirectToAction(""); // TODO: specify appropriate action name

            return Ok(childThemes);
        }

        /// <summary>
        /// Теми вищого рівня
        /// </summary>
        /// <param name="courseId">Ідентифікатор курсу</param>
        /// <param name="levelId">Рівень складності</param>
        /// <param name="langCode">Код мови, якій надавати перевагу</param>
        /// <returns>Список тем вищого рівня для курсу</returns>
        /// <response code="200">Операція виконана успішно</response>
        /// <response code="302">Перенаправлення на останню тему, переглянуту
        /// користувачем</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [Route("~/api/[controller]/themes/parents")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<IActionResult> GetUserCourseThemesLocalAsync(int courseId, 
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