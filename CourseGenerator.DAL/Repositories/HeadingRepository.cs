using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System.Linq;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingRepository : GenericEFRepository<Heading>, IHeadingRepository
    {
        public HeadingRepository(ApplicationContext context) : base(context)
        {
        }

        public string GetLastCode(string code = null)
        {
            if (code != null)
            {
                int point = code.Count(s => s == '.') + 1;

                string newCode = _context.Headings
                 .Where(h => h.Code.StartsWith(code) && h.Code.Count(s => s == '.') < point)
                 .Select(h => h.Code)
                 .Max();

                return newCode;
            }
            else
            {
                return _context.Headings.Select(h => h.Code).Max();
            }
        }
    }
}
