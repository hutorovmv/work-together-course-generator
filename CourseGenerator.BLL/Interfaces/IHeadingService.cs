using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    /// <summary>
    /// Сервіс для роботи з рубриками
    /// </summary>
    public interface IHeadingService : IDisposable
    {
        /// <summary>
        /// Створює нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingDto">Об'єкт передачі даних для нелокалізованої 
        /// частини</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        Task<OperationInfo> CreateAsync(HeadingDTO headingDto);

        /// <summary>
        /// Створює локалізацію для вказаної рубрики вказаною мовою.
        /// </summary>
        /// <param name="headingLangDto">Об'єкт передачі даних, що містить 
        /// локалізовану частину сутності - Рубрика</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        Task<OperationInfo> CreateLocalAsync(HeadingLangDTO headingLangDto);

        /// <summary>
        /// Оновлює нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingDto">Об'єкт передачі даних для нелокалізованої 
        /// частини</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        Task<OperationInfo> UpdateAsync(HeadingDTO headingDto);

        /// <summary>
        /// Створює локалізацію для вказаної рубрики вказаною мовою.
        /// </summary>
        /// <param name="headingLangDto">Об'єкт передачі даних, що містить 
        /// локалізовану частину сутності - Рубрика</param>
        Task<OperationInfo> UpdateLocalAsync(HeadingLangDTO headingLangDto);

        /// <summary>
        /// Видаляє рубрику та всі (та всі її локалізації).
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        Task<OperationInfo> DeleteAsync(int id);

        /// <summary>
        /// Видаляє локалізацію рубрики.
        /// </summary>
        /// <param name="id">Ідентифікатор рубрики</param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Інформацію про успішність виконання операції</returns>
        Task<OperationInfo> DeleteLocalAsync(int id, string langCode);

        /// <summary>
        /// Отримує нелокалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingId">Ідентифікатор рубрики, яка локалізується
        /// </param>
        /// <returns>Об'єкт передачі даних для нелокалізованої частини</returns>
        Task<HeadingDTO> GetAsync(int id);

        /// <summary>
        /// Отримує локалізовану частину сутності - Рубрика.
        /// </summary>
        /// <param name="headingId">Ідентифікатор рубрики, 
        /// для якої призначена локалізується</param>
        /// <param name="langCode">Код мови локалізації</param>
        /// <returns>Об'єкт передачі даних для локалізованої частини</returns>
        Task<HeadingLangDTO> GetLocalAsync(int id, string langCode);

        /// <summary>
        /// Отримує ієрархію рубрик до даної рубрики включно.
        /// </summary>
        /// <param name="code">Код рубрики, для якої необхідно отримати ієрархію
        /// </param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Локалізовану ієрархію рубрик, до даної включно</returns>
        IEnumerable<HeadingLangDTO> GetParentsLocal(string code, 
            string langCode);

        /// <summary>
        /// Отримує підрубрики для даної рубрики.
        /// </summary>
        /// <param name="code">Код рубрики, для якої необзідно отримати 
        /// підрубрики</param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Отримує всіх прямих потомків даної підрубрики</returns>
        Task<IEnumerable<HeadingLangDTO>> GetSubsLocalAsync(string code, 
            string langCode);
    }
}
