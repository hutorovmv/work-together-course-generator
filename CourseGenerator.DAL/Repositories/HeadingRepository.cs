using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingRepository : GenericEFRepository<Heading>, IHeadingRepository
    {
        public HeadingRepository(ApplicationContext context) : base(context)
        {
        }
        /// <summary>
        /// Відбирає останню підрубрику
        /// </summary>
        /// <param name="code">Код рубрики, у форматі Х.Х.Х</param>
        /// <returns></returns>
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

        /// <inheritdoc/>
        public async Task<IEnumerable<HeadingLang>> GetSubsLocalAsync(string code, string langCode)
        {
            int point = code.Count(s => s == '.');

            IQueryable<string> subHeadingCodes = _context.Headings
                .Where(h => h.Code.StartsWith(code) && h.Code.Count(s => s == '.') - point == 1)
                .Select(h => h.Code);

            IQueryable<HeadingLang> headingsLocal = _context.HeadingLangs
                .Include(hl => hl.Heading)
                .Where(hl => hl.LangCode == langCode 
                && subHeadingCodes.Contains(hl.Heading.Code));

            IQueryable<HeadingLang> headingsDefault = _context.HeadingLangs
                .Include(hl => hl.Heading)
                .Where(hl => !headingsLocal
                    .Select(hl => hl.Heading.Code) // TODO: rename param if errors
                    .Contains(hl.Heading.Code));

            IQueryable<HeadingLang> headingLangs = headingsLocal
                .Union(headingsDefault)
                .OrderBy(l => l.Heading.Code); // TODO: inclure l.Heading if errors

            return await headingLangs.ToListAsync();
        }

        //TODO: Try new variant with regular expressions
        public async IAsyncEnumerable<HeadingLang> GetParentsLocalAsync(string code, string langCode)
        {
            Stack<string> codeByDots = new Stack<string>(code.Split('.'));
            string parent;

            for(int i = 0; i < codeByDots.Count - 1; i++)
            {
                parent = string.Join('.', codeByDots);
                codeByDots.Pop();
                yield return await GetHeadingLangAsync(parent, langCode);
            }
        }

        public async Task<HeadingLang> GetHeadingLangAsync(string code, string langCode)
        {
            HeadingLang headingLangs = await _context.HeadingLangs
                .Include(h => h.Heading)
                .FirstOrDefaultAsync(h => h.Heading.Code == code 
                && h.LangCode == langCode);

            if (headingLangs == null)
            {
                headingLangs = await _context.HeadingLangs
                    .Include(hl => hl.Heading)
                    .FirstOrDefaultAsync(h => h.Heading.Code == code);
            }

            return headingLangs;
        }

    }
}
