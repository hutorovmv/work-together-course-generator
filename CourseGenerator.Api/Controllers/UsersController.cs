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
using System.Threading.Tasks;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер для роботи з користувачами
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Контролер для роботи з користувачами")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserManagementService _userManagementService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Об'єкт мапера</param>
        /// <param name="userManagementService">Сервіс для керування 
        /// користувачами</param>
        public UsersController(IMapper mapper, 
            IUserManagementService userManagementService)
        {
            _mapper = mapper;
            _userManagementService = userManagementService;
        }

        /// <summary>
        /// Cтворює аккаунт
        /// </summary>
        /// <param name="registrationModel">Дані для реєстрації</param>
        /// <returns>Статус-код</returns>
        /// <response code="201">Акаунт створено</response>
        /// <response code="400">Помилка при виконанні запиту</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(
            [FromBody] UserRegistrationModel registrationModel)
        {
            RegisterDTO registrationDto = _mapper
                .Map<RegisterDTO>(registrationModel);
            OperationInfo registrationResult = await _userManagementService
                .CreateAsync(registrationDto, "User");

            if (registrationResult.Succeeded)
                return StatusCode(StatusCodes.Status201Created);
            return BadRequest(registrationModel);
        }
    }
}