using AutoMapper;
using CourseGenerator.Api.Models.User;
using CourseGenerator.BLL.DTO.User;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер для роботи з налаштуваннями
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Контролер для роботи з налаштуваннями")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public class SettingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserManagementService _userManagementService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Об'єкт мапера</param>
        /// <param name="userManagementService">Сервіс для керування 
        /// користувачами</param>
        public SettingsController(IMapper mapper,
            IUserManagementService userManagementService)
        {
            _mapper = mapper;
            _userManagementService = userManagementService;
        }

        /// <summary>
        /// Зміна налаштувань профілю
        /// </summary>
        /// <param name="userSettingsModel">Налаштування які можна змінити
        /// </param>
        /// <returns>Статус-код</returns>
        /// <response code="200">Налаштування змінено</response>
        /// <response code="400">Помилка при виконанны запиту</response>
        /// <response code="401">Неавторизовано</response>
        [Authorize]
        [Route("profile")]
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateSettingsAsync(
            UserSettingsModel userSettingsModel)
        {
            UserSettingsDTO userSettingsDto = _mapper
                .Map<UserSettingsDTO>(userSettingsModel);

            OperationInfo result = await _userManagementService
                .UpdateProfileAsync(userSettingsDto);
            if (!result.Succeeded)
                return BadRequest(result.Message);

            return Ok();
        }

        /// <summary>
        /// Зміна мови користувача
        /// </summary>
        /// <param name="langCode">Мова користувача</param>
        /// <returns>Статус-код</returns>
        /// <response code="200">Налаштування змінено</response>
        /// <response code="400">Помилка при виконанны запиту</response>
        /// <response code="401">Неавторизовано</response>
        [Authorize]
        [Route("lang")]
        [HttpPut]
        [Consumes(MediaTypeNames.Text.Plain)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateLangAsync(string langCode)
        {
            UserSettingsDTO userSettingsDto = new UserSettingsDTO
            {
                Id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                PreferedLangCode = langCode
            };

            OperationInfo result = await _userManagementService
                .UpdateProfileAsync(userSettingsDto);
            if (!result.Succeeded)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}