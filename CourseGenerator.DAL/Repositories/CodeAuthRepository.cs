using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class CodeAuthRepository: GenericEFRepository<CodeAuth>, ICodeAuthRepository
    {
        public CodeAuthRepository(ApplicationContext context): base(context)
        {
        }

        public async Task<CodeAuth> GetByCodeAsync(string code)
        {
            CodeAuth codeAuth = await _context.CodeAuths.FirstOrDefaultAsync(p => p.Code == code);
            return codeAuth;
        }
    }
}
