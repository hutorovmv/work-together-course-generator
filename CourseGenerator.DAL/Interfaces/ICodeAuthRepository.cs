using CourseGenerator.Models.Entities.Security;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    public interface ICodeAuthRepository : IRepository<CodeAuth>
    {
        Task<CodeAuth> GetAsync(string code);
    }
}
