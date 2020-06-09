using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGenerator.Api.Controllers.Generic
{
#pragma warning disable CS1591
    /// <summary>
    /// CRUD контролер
    /// </summary>
    /// <typeparam name="TViewModel">
    /// ViewModel, з якою працює контролер
    /// </typeparam>
    /// <typeparam name="TDTO">DTO, з яким пряцює сервіс</typeparam>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public abstract class CrudController<TViewModel, TDTO> 
        : ControllerBase
        where TViewModel : class
        where TDTO : class
    {
        protected readonly IMapper _mapper;
        protected readonly ICrudService<object, TDTO> _crudService;

        protected string UserId => HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        public CrudController(IMapper mapper, 
            ICrudService<object, TDTO> crudService)
        {
            _mapper = mapper;
            _crudService = crudService;
        }

        /// <summary>
        /// Створює нелокалізовану частину даних сутності
        /// </summary>
        /// <param name="model">
        /// ViewModel для нелокалізованої частини сутності
        /// </param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="201">Створено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateAsync(TViewModel model)
        {
            TDTO dto = _mapper.Map<TDTO>(model);

            OperationInfo result = await _crudService.CreateAsync(UserId, dto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Отримує нелокалізовану частину даних сутності
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Виконано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            TDTO dto = await _crudService.GetAsync(UserId, id);
            TViewModel model = _mapper.Map<TViewModel>(dto);
            return Ok(model);
        }

        /// <summary>
        /// Оновлює дані про об'єкт сутності
        /// </summary>
        /// <param name="model">
        /// ViewModel для нелокалізованої частини сутності
        /// </param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Оновлено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateAsync(TViewModel model)
        {
            TDTO dto = _mapper.Map<TDTO>(model);

            OperationInfo result = await _crudService.UpdateAsync(UserId, dto);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Видаляє об'єкт сутності
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Рубрику видалено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            OperationInfo result = await _crudService.DeleteAsync(UserId, id);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Message);
        }
    }
    #pragma warning restore CS1591
}