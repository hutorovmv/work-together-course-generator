using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер, що містить методи, для роботи з мовами
    /// </summary>
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json, new string[] { MediaTypeNames.Application.Xml })]
    [ApiController]
    [SwaggerTag("Контролер, що містить методи, для роботи з мовами")]
    public class LanguagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILanguageService _languageService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper">Мапер (<see cref="IMapper"/>)</param>
        /// <param name="languageService">Сервіс для роботу з мовами</param>
        public LanguagesController(IMapper mapper, ILanguageService languageService)
        {
            _mapper = mapper;
            _languageService = languageService;
        }
        
        /// <summary>
        /// Метод, що повертає список усіх доступних мов
        /// </summary>
        /// <returns>Список мов</returns>
        /// <response code="200">Мови відібрано успішно</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<LanguageSelectDTO>> GetLanguageSelectCollection()
        {
            IEnumerable<LanguageSelectDTO> languageSelectDtos = await _languageService.GetAllAsync();
            return languageSelectDtos;
        }
    }
}