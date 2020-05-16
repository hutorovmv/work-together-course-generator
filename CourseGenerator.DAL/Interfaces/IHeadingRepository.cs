using CourseGenerator.Models.Entities.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IHeadingRepository : IRepository<Heading>
    {
        string GetLastCode(string code);

        /// <summary>
        /// Відбирає локалізовані підрубрики, використовуючи код рубрики
        /// </summary>
        /// <param name="code">Код рубрики, у форматі Х.Х.Х</param>
        /// <param name="langCode">Код мови</param>
        /// <returns>Колекцію кодів підрубрик</returns>
        Task<IEnumerable<HeadingLang>> GetSubsLocalAsync(string code, string langCode);
        IAsyncEnumerable<HeadingLang> GetParentsLocalAsync(string code, string langCode);
        Task<HeadingLang> GetLocalOrDefaultAsync(string code, string langCode);
    }
}
