using AutoMapper;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LanguageSelectDTO>> GetAllAsync()
        {
            IEnumerable<Language> languages = await _uow.LanguageRepository.GetAllAsync();
            IEnumerable<LanguageSelectDTO> languageSelectDtos = _mapper
                .Map<IEnumerable<LanguageSelectDTO>>(languages);
            return languageSelectDtos;
        }

        public void Dispose() => _uow.Dispose();
    }
}
