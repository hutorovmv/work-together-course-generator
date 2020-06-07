using AutoMapper;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.BLL.Interfaces.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Controllers.Generic
{
#pragma warning disable CS1591
    /// <summary>
    /// CRUD контролер локалізацій
    /// </summary>
    /// <typeparam name="TViewModelLocal">
    /// ViewModel, з якою працює контролер
    /// </typeparam>
    /// <typeparam name="TDTOLocal">DTO, з яким пряцює сервіс</typeparam>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public abstract class CrudLocalController<TViewModelLocal, TDTOLocal> 
        : ControllerBase
        where TViewModelLocal : class
        where TDTOLocal : class, ILocal
    {
        protected readonly IMapper _mapper;
        protected readonly ICrudLocalService<object, TDTOLocal> 
            _localCrudService;

        protected string UserId => HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        public CrudLocalController(IMapper mapper, 
            ICrudLocalService<object, TDTOLocal> localCrudService)
        {
            _mapper = mapper;
            _localCrudService = localCrudService;
        }

        /// <summary>
        /// Створює дані сутності, локалізовані вказаною мовою
        /// </summary>
        /// <param name="model">
        /// ViewModel для локалізованої частини сутності
        /// </param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="201">Локалізацію створено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        /// <response code="404">Помилка при виконанні</response>
        [HttpPost]
        [Route("{lang}")]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> CreateLocalAsync(
            TViewModelLocal model, string lang)
        {
            TDTOLocal dto = _mapper.Map<TDTOLocal>(model);
            dto.LangCode = lang;

            OperationInfo result = await _localCrudService
                .CreateLocalAsync(UserId, dto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Отримує дані сутності локалізовані вказаною мовою
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Локалізацію успішно отримано</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetLocalAsync(int id, string lang)
        {
            TDTOLocal dto = await _localCrudService
                .GetLocalAsync(UserId, lang, id);
            TViewModelLocal model = _mapper.Map<TViewModelLocal>(dto);
            return Ok(model);
        }

        /// <summary>
        /// Оновлює дані сутності, локалізовані вказаною мовою
        /// </summary>
        /// <param name="model">
        /// ViewModel для локалізованої частини сутності
        /// </param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Рубрику оновлено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPut]
        [Route("{lang}")]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> UpdateLocalAsync(TViewModelLocal model, 
            string lang)
        {
            TDTOLocal dto = _mapper.Map<TDTOLocal>(model);
            dto.LangCode = lang;

            OperationInfo result = await _localCrudService
                .UpdateLocalAsync(UserId, dto);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Видаляє дані сутності, локалізовані вказаною мовою
        /// </summary>
        /// <param name="id">Ідентифікатор</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Локалізацію видалено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpDelete]
        [Route("{lang}/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> DeleteLocalAsync(int id, string lang)
        {
            OperationInfo result = await _localCrudService
                .DeleteLocalAsync(UserId, lang, id);
            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Message);
        }
    }
    #pragma warning restore CS1591
}
