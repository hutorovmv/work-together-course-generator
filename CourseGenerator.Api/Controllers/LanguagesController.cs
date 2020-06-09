using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.Api.Models.Selection;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers
{
    /// <summary>
    /// Контролер, що містить методи, для роботи з мовами
    /// </summary>
    [ApiController]
    //[ApiExplorerSettings(GroupName = "Language")]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json, 
        new string[] { MediaTypeNames.Application.Xml })]
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
        public LanguagesController(IMapper mapper, 
            ILanguageService languageService)
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
        public async Task<IEnumerable<LanguageSelectModel>> GetSelectsAsync()
        {
            IEnumerable<LanguageSelectDTO> langSelectDtos = await 
                _languageService.GetAllAsync();
            IEnumerable<LanguageSelectModel> lengSelectModels = _mapper
                .Map<IEnumerable<LanguageSelectModel>>(langSelectDtos);
            return lengSelectModels;
        }
    }
}