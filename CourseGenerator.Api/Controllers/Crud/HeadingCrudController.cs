using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Controllers.Crud {
    [Route("api/headings")]
    //[ApiExplorerSettings(GroupName = "Heading")]
    [SwaggerTag("Контролер для роботи з нелокалізованими частинами рубрик")]
    public class HeadingCrudController
        : CrudController<HeadingModel, HeadingDTO>
    {
        public HeadingCrudController(IMapper mapper,
            IHeadingServiceUpgrade crudService) : base(mapper, crudService)
        {
        }

        /// <summary>
        /// Створює нелокалізовану частину даних рубрики
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
        public override async Task<IActionResult> CreateAsync(HeadingModel model)
        {
            HeadingDTO dto = _mapper.Map<HeadingDTO>(model);

            int? id = await (_crudService as IHeadingServiceUpgrade)
                .CreateAsync(UserId, dto);
            if (id.HasValue)
                return StatusCode(StatusCodes.Status201Created, id);

            return BadRequest();
        }

        /// <summary>
        /// Створює нелокалізовану частину даних підрубрики та повертає id.
        /// </summary>
        /// <param name="model">
        /// ViewModel для нелокалізованої частини сутності
        /// </param>
        /// <param name="parent">
        /// Код для ієрархії рубрики вищого рівня
        /// </param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="201">Створено успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpPost]
        [Route("child/{parent}")]
        [Consumes(MediaTypeNames.Application.Json,
            new string[] { MediaTypeNames.Application.Xml })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateChildAsync(HeadingModel model, 
            string parent)
        {
            HeadingDTO dto = _mapper.Map<HeadingDTO>(model);

            int? id = await (_crudService as IHeadingServiceUpgrade)
                .CreateAsync(UserId, dto, parent);
            
            if (id.HasValue)
                return StatusCode(StatusCodes.Status201Created, id);

            return BadRequest();
        }
    }
}
