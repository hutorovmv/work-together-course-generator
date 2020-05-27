using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<HeadingLang>> GetChildrenLocalAsync(string id, string langCode)
        {
            int point = id.Count(s => s == '.');

            IQueryable<string> subHeadingCodes = _context.Headings
                .Where(h => h.Code.StartsWith(id) && h.Code.Count(s => s == '.') - point == 1)
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

        /// <summary>
        /// Метод, що отримує усі рубрики вищого рівня
        /// </summary>
        /// <param name="code">Код рубрики, у вигляді Х.Х.Х</param>
        /// <param name="langCode">Код мови, для рубрик вищого рівня</param>
        /// <returns></returns>
        //TODO: Try new variant with regular expressions
        public async IAsyncEnumerable<HeadingLang> GetAncestorsAsync(string code, 
            string langCode)
        {
            Stack<string> codeByDots = new Stack<string>(code.Split('.'));
            string parent;

            for(int i = 0; i < codeByDots.Count - 1; i++)
            {
                codeByDots.Pop();
                parent = string.Join('.', codeByDots);  
                yield return await GetLocalOrDefaultAsync(parent, langCode);
            }
        }

        public async Task<HeadingLang> GetLocalOrDefaultAsync(string code, 
            string langCode)
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

        public override void Delete(Heading heading)
        {
            string code = heading.Code;
            bool haveChildren = _context.Set<Heading>().Any(h => 
                h.Code.StartsWith(code) 
                && h.Code.Length > code.Length);

            if (haveChildren)
                throw new Exception("This heading contains subheadings");

            bool isConnected = heading.HeadingCompetencies.Any()
                || heading.CourseHeadings.Any()
                || heading.HeadingMaterials.Any()
                || heading.UserHeadings.Any(); // ???

            if (!isConnected)
                base.Delete(heading);
            else
                throw new Exception("There may be connected rows in tables:\n" +
                    "\tCourseHeadings" +
                    "\tHeadingMaterials" +
                    "\tUserHeadings");
        }

        public async Task<IEnumerable<HeadingLang>> GetRootLocalAsync(string langCode)
        {
            return await _context.HeadingLangs
                .Include(hl => hl.Heading)
                .Where(hl => !hl.Heading.Code.Contains('.') && hl.LangCode == langCode).ToListAsync();
        }

        public async Task<HeadingLang> GetParentsLocalAsync(string id, string langCode)
        {
            Stack<string> codeByDots = new Stack<string>(id.Split('.'));
            codeByDots.Pop();
            string parent = string.Join('.', codeByDots);
            return await GetLocalOrDefaultAsync(parent, langCode);
        }

    }

}
