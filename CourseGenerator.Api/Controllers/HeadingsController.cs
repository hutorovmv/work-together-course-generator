using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.Api.Models.Locals;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер для роботи з рубриками
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Контролер для роботи з рубриками")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public class HeadingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHeadingService _headingService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Об'єкт мапера</param>
        /// <param name="headingService">Сервіс для керування 
        /// користувачами</param>
        public HeadingsController(IMapper mapper,
            IHeadingService headingService)
        {
            _mapper = mapper;
            _headingService = headingService;
        }

        // TODO: Create default localization

        /// <summary>
        /// Створює рубрику
        /// </summary>
        /// <param name="headingModel">ViewModel для нелокалізованої частини
        /// сутності - Рубрика</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="201">Рубрику створено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(HeadingModel headingModel)
        {
            HeadingDTO headingDto = _mapper.Map<HeadingDTO>(headingModel);
            
            OperationInfo result = await _headingService.CreateAsync(headingDto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Створює локалізацію рубрики вказаною мовою
        /// </summary>
        /// <param name="headingLangModel">ViewModel для локалізованої частини
        /// сутності - Рубрика</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="201">Локалізацію створено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        /// <response code="404">Помилка при виконанні</response>
        [HttpPost]
        [Route("{lang}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLocalAsync(
            HeadingLangModel headingLangModel, string lang)
        {
            HeadingLangDTO headingLangDto = _mapper
                .Map<HeadingLangDTO>(headingLangModel);
            headingLangDto.LangCode = lang;

            OperationInfo result = await _headingService
                .CreateLocalAsync(headingLangDto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status201Created);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Оновлює дані про рубрику
        /// </summary>
        /// <param name="headingModel">ViewModel для нелокалізованої частини
        /// сутності - Рубрика</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Рубрику оновлено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(HeadingModel headingModel)
        {
            HeadingDTO headingDto = _mapper.Map<HeadingDTO>(headingModel);

            OperationInfo result = await _headingService
                .UpdateAsync(headingDto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status204NoContent);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Оновлює дані про локалізацію рубрики
        /// </summary>
        /// <param name="headingLangModel">ViewModel для локалізованої частини
        /// сутності - Рубрика</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Локалізацію оновлено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPut]
        [Route("{lang}")]
        public async Task<IActionResult> UpdateLocalAsync(
            HeadingLangModel headingLangModel, string lang)
        {
            HeadingLangDTO headingLangDto = _mapper
                .Map<HeadingLangDTO>(headingLangModel);
            headingLangDto.LangCode = lang;

            OperationInfo result = await _headingService
                .UpdateLocalAsync(headingLangDto);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status204NoContent);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Видаляє рубрику
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Рубрику видалено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            OperationInfo result = await _headingService
                .DeleteAsync(id);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status204NoContent);

            return BadRequest(result.Message);
        }

        // TODO: Allow to delete localization only if there is at least two

        /// <summary>
        /// Видаляє локалізацію рубрики
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="204">Локалізацію видалено успішно</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpDelete]
        [Route("{lang}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteLocalAsync(int id, 
            string lang)
        {
            OperationInfo result = await _headingService
                .DeleteLocalAsync(id, lang);
            if (result.Succeeded)
                return StatusCode(StatusCodes.Status204NoContent);

            return BadRequest(result.Message);
        }

        /// <summary>
        /// Отримує нелокалізовану частину рубрики
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Рубрику успішно отримано</response>
        /// <response code="400">Помилка при виконанні</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync(int id)
        {
            HeadingDTO headingDto = await _headingService.GetAsync(id);
            HeadingModel headingModel = _mapper.Map<HeadingModel>(headingDto);
            return Ok(headingModel);
        }

        /// <summary>
        /// Отримує локалізацію рубрики
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Локалізацію успішно отримано</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLocalAsync(int id, string lang)
        {
            HeadingLangDTO headingLangDto = await _headingService
                .GetLocalAsync(id, lang);
            HeadingLangModel headingLangModel = _mapper
                .Map<HeadingLangModel>(headingLangDto);
            return Ok(headingLangModel);
        }

        /// <summary>
        /// Отримує рубрики вищого рівня (з даною рубрикою включно)
        /// </summary>
        /// <param name="code">Код рубрики</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Успішно отримано рубрики вищого рівня
        /// </response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}/parents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetParentsLocal(string code, 
            string lang)
        {
            IEnumerable<HeadingLangDTO> headingLangDtos = _headingService
                .GetParentsLocal(code, lang);
            IEnumerable<HeadingLangModel> headingLangModels = _mapper
                .Map<IEnumerable<HeadingLangModel>>(headingLangDtos);
            return Ok(headingLangModels);
        }

        /// <summary>
        /// Отримує підрубрики
        /// </summary>
        /// <param name="code">Код рубрики</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Успішно отримано підрубрики</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPost]
        [Route("{lang}/subheadings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubsLocalAsync(string code, 
            string lang)
        {
            IEnumerable<HeadingLangDTO> headingLangDtos = await _headingService
                .GetSubsLocalAsync(code, lang);
            IEnumerable<HeadingLangModel> headingLangModels = _mapper
                .Map<IEnumerable<HeadingLangModel>>(headingLangDtos);
            return Ok(headingLangModels);
        }
    }
}