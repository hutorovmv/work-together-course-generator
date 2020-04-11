using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILanguageService _languageService;

        public LanguagesController(IMapper mapper, ILanguageService languageService)
        {
            _mapper = mapper;
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageSelectDTO>> GetLanguageSelectCollection()
        {
            IEnumerable<LanguageSelectDTO> languageSelectDtos = await _languageService.GetAllAsync();
            return languageSelectDtos;
        }
    }
}