using AutoMapper;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Services
{
    /// <summary>
    /// Сервіс для роботи з рубриками
    /// </summary>
    public class HeadingService : IHeadingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="uow">Unit of Work, містить в собі посилання 
        /// на репозиторії</param>
        /// <param name="mapper">Мапер, необхідний для перетворння 
        /// об'єктів</param>
        public HeadingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // TODO: Add user permissions check

        /// <summary>
        /// Створює нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingDto">Об'єкт передачі даних для нелокалізованої 
        /// частини</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        public async Task<OperationInfo> CreateAsync(HeadingDTO headingDto)
        {
            try
            {
                Heading heading = _mapper.Map<Heading>(headingDto);

                await _uow.HeadingRepository.CreateAsync(heading);
                await _uow.SaveAsync();

                return new OperationInfo(true, "Heading was created " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        /// <summary>
        /// Створює локалізацію для вказаної рубрики вказаною мовою.
        /// </summary>
        /// <param name="headingLangDto">Об'єкт передачі даних, що містить 
        /// локалізації для полів,
        /// що її потребують</param>
        /// <param name="headingId">Ідентифікатор рубрики, яка 
        /// локалізується</param>
        /// <param name="langCode">Код мови локалізації</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        public async Task<OperationInfo> CreateLocalAsync(
            HeadingLangDTO headingLangDto, int headingId, string langCode)
        {
            try
            {
                HeadingLang headingLang = _mapper
                    .Map<HeadingLang>(headingLangDto);
                headingLang.HeadingId = headingId;
                headingLang.LangCode = langCode;

                await _uow.HeadingLangRepository.CreateAsync(headingLang);
                await _uow.SaveAsync();

                return new OperationInfo(true, "HeadingLang was created " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        /// <summary>
        /// Оновлює нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingDto">Об'єкт передачі даних для нелокалізованої 
        /// частини</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        public async Task<OperationInfo> UpdateAsync(HeadingDTO headingDto)
        {
            try
            {
                Heading heading = _mapper.Map<Heading>(headingDto);

                _uow.HeadingRepository.Update(heading);
                await _uow.SaveAsync();

                return new OperationInfo(true, "Heading was updated " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        /// <summary>
        /// Створює локалізацію для вказаної рубрики вказаною мовою.
        /// </summary>
        /// <param name="headingLangDto">Об'єкт передачі даних, що містить 
        /// локалізації для полів,
        /// що її потребують</param>
        /// <param name="headingId">Ідентифікатор рубрики, яка 
        /// локалізується</param>
        /// <param name="langCode">Код мови локалізації</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        public async Task<OperationInfo> UpdateLocalAsync(
            HeadingDTO headingLangDto, int headingId, string langCode)
        {
            try
            {
                HeadingLang headingLang = _mapper
                    .Map<HeadingLang>(headingLangDto);
                headingLang.HeadingId = headingId;
                headingLang.LangCode = langCode;

                _uow.HeadingLangRepository.Update(headingLang);
                await _uow.SaveAsync();

                return new OperationInfo(true, "HeadingLang was updated " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        /// <summary>
        /// Видаляє рубрику та всі (та всі її локалізації).
        /// </summary>
        /// <param name="headingDto">Об'єкт передачі даних для нелокалізованої 
        /// частини</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        public async Task<OperationInfo> Delete(HeadingDTO headingDto)
        {
            try
            {
                // TODO: Check if there are subheadings of other users
                Heading heading = await _uow.HeadingRepository
                    .GetAsync(headingDto.Id);

                _uow.HeadingRepository.Delete(heading);
                await _uow.SaveAsync();

                return new OperationInfo(true, "Heading was deleted " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }
                                                                                
        /// <summary>
        /// Отримує нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingId">Ідентифікатор рубрики, яка локалізується
        /// </param>
        /// <returns>Об'єкт передачі даних для нелокалізованої частини</returns>
        public async Task<HeadingDTO> GetAsync(int headingId)
        {
            Heading heading = await _uow.HeadingRepository.GetAsync(headingId);
            return _mapper.Map<HeadingDTO>(heading);
        }

        /// <summary>
        /// Отримує локалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingId">Ідентифікатор рубрики, 
        /// для якої призначена локалізується</param>
        /// <param name="langCode">Код мови локалізації</param>
        /// <returns>Об'єкт передачі даних для локалізованої частини</returns>
        public async Task<HeadingLangDTO> GetLocalAsync(int headingId, 
            string langCode)
        {
            HeadingLang headingLang = await _uow.HeadingLangRepository
                .GetAsync(headingId, langCode);
            return _mapper.Map<HeadingLangDTO>(headingLang);
        }

        /// <summary>
        /// Отримує ієрархію рубрик до даної рубрики включно.
        /// </summary>
        /// <param name="code">Код рубрики, для якої необхідно отримати ієрархію
        /// </param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Локалізовану ієрархію рубрик, до даної включно</returns>
        public IEnumerable<HeadingLangDTO> GetParentsLocalAsync(string code,
            string langCode)
        {
            IAsyncEnumerable<HeadingLang> parents = _uow.HeadingRepository
                .GetParentsLocalAsync(code,
                langCode);
            IEnumerable<HeadingLangDTO> parentDtos = _mapper
                .Map<IEnumerable<HeadingLangDTO>>(parents);
            return parentDtos;
        }

        /// <summary>
        /// Отримує підрубрики для даної рубрики.
        /// </summary>
        /// <param name="code">Код рубрики, для якої необзідно отримати 
        /// підрубрики</param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Отримує всіх прямих потомків даної підрубрики</returns>
        public async Task<IEnumerable<HeadingLangDTO>> GetSubsLocalAsync(
            string code, string langCode)
        {
            IEnumerable<HeadingLang> subHeadings = await _uow.HeadingRepository
                .GetSubsLocalAsync(code,
                langCode);
            IEnumerable<HeadingLangDTO> subHeadingDtos = _mapper
                .Map<IEnumerable<HeadingLangDTO>>(subHeadings);
            return subHeadingDtos;
        }

        /// <inheritdoc/>
        public void Dispose() => _uow.Dispose();
    }
}