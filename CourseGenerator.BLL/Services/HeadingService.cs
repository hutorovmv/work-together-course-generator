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
    /// Реалізація сервісу для роботи з рубриками
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
    
        /// <inheritdoc/>
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
        
        /// <inheritdoc/>
        public async Task<OperationInfo> CreateLocalAsync(
            HeadingLangDTO headingLangDto)
        {
            try
            {
                HeadingLang headingLang = _mapper
                    .Map<HeadingLang>(headingLangDto);

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
        
        /// <inheritdoc/>
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
        
        /// <inheritdoc/>
        public async Task<OperationInfo> UpdateLocalAsync(
            HeadingLangDTO headingLangDto)
        {
            try
            {
                HeadingLang headingLang = _mapper
                    .Map<HeadingLang>(headingLangDto);

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
        
        /// <inheritdoc/>
        public async Task<OperationInfo> DeleteAsync(int id)
        {
            try
            {
                // TODO: Check if there are subheadings of other users
                Heading heading = await _uow.HeadingRepository
                    .GetAsync(id);

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

        /// <inheritdoc/>
        public async Task<OperationInfo> DeleteLocalAsync(int id, 
            string langCode)
        {
            try
            {
                HeadingLang headingLang = await _uow.HeadingLangRepository
                    .GetAsync(id);

                _uow.HeadingLangRepository.Delete(headingLang);
                await _uow.SaveAsync();

                return new OperationInfo(true, "HeadingLang was deleted " +
                    "successfuly");
            }
            catch (Exception ex)
            {
                return new OperationInfo(false, ex.Message);
            }
        }

        // TODO: Check if there are subheadings of other users
        /// <inheritdoc/>
        public async Task<HeadingDTO> GetAsync(int id)
        {
            Heading heading = await _uow.HeadingRepository.GetAsync(id);
            return _mapper.Map<HeadingDTO>(heading);
        }
        
        /// <inheritdoc/>
        public async Task<HeadingLangDTO> GetLocalAsync(int id, 
            string langCode)
        {
            HeadingLang headingLang = await _uow.HeadingLangRepository
                .GetAsync(id, langCode);
            return _mapper.Map<HeadingLangDTO>(headingLang);
        }
        
        /// <inheritdoc/>
        public IEnumerable<HeadingLangDTO> GetParentsLocal(string code,
            string langCode)
        {
            IAsyncEnumerable<HeadingLang> parents = _uow.HeadingRepository
                .GetParentsLocalAsync(code, langCode);
            IEnumerable<HeadingLangDTO> parentDtos = _mapper
                .Map<IEnumerable<HeadingLangDTO>>(parents);
            return parentDtos;
        }
        
        /// <inheritdoc/>
        public async Task<IEnumerable<HeadingLangDTO>> GetSubsLocalAsync(
            string code, string langCode)
        {
            IEnumerable<HeadingLang> subHeadings = await _uow.HeadingRepository
                .GetSubsLocalAsync(code, langCode);
            IEnumerable<HeadingLangDTO> subHeadingDtos = _mapper
                .Map<IEnumerable<HeadingLangDTO>>(subHeadings);
            return subHeadingDtos;
        }

        /// <inheritdoc/>
        public void Dispose() => _uow.Dispose();
    }
}