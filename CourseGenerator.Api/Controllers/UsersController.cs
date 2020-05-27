using AutoMapper;
using CourseGenerator.Api.Models.User;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.DTO.User;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Pagination;
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
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
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

        /// <summary>
        /// Отримує дані про окремого користувача
        /// </summary>
        /// <param name="id">Ідентифікатор користувача</param>
        /// <returns>Дані про користувача</returns>
        /// <response code="200">Отримано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{id}")]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(string id)
        {
            UserDTO userDto = await _userManagementService.GetAsync(id);
            UserModel userModel = _mapper.Map<UserModel>(userDto);
            return Ok(userDto);
        }

        /// <summary>
        /// Здійснює відбір користувачів за критеріями
        /// </summary>
        /// <param name="firstName">Ім'я</param>
        /// <param name="lastName">Прізвище</param>
        /// <param name="userName">Ім'я користувача</param>
        /// <param name="roleName">Роль</param>
        /// <param name="pageSize">Розмір сторінки</param>
        /// <param name="pageIndex">Індекс сторінки</param>
        /// <returns>Дані про користувачів з пагінацією</returns>
        /// <response code="200">Отримано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPagedAsync(string firstName, 
            string lastName, string userName, string roleName, int pageSize = 6, 
            int pageIndex = 1)
        {
            PagedList<UserDTO> userDto = await _userManagementService
                .GetPagedAsync(firstName, lastName, userName, roleName,
                pageSize, pageIndex);
            UserModel userModel = _mapper.Map<UserModel>(userDto);
            return Ok(userDto);
        }

        /// <summary>
        /// Видаляє користувача
        /// </summary>
        /// <param name="id">Ідентифікатор користувача</param>
        /// <returns>Інформацію про виконання операції або статус-код</returns>
        /// <response code="204">Видалено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            OperationInfo result = await _userManagementService.DeleteAsync(id);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Message);
        }
    }
}