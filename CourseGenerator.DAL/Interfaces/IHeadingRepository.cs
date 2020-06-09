using CourseGenerator.Models.Entities.Info;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IHeadingRepository : IRepository<Heading>, IHierarchyLocal<string, HeadingLang>
    {
        string GetLastCode(string code);

        IAsyncEnumerable<HeadingLang> GetAncestorsAsync(string code, string langCode);
        Task<HeadingLang> GetLocalOrDefaultAsync(string code, string langCode);
        Task<IEnumerable<MaterialLang>> GetMaterialLangsAsync(int id, string langCode);
        string GetCode(int id);
    }
}
