using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class MaterialRepository: GenericEFRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationContext context): base(context) {}

        public async Task<IEnumerable<Material>> GetChildrenAsync(int childrenId)
        {
            return await _context.MaterialBlocks
                .Where(cm => cm.ChildId == childrenId)
                .Select(cm => cm.ChildMaterial).ToListAsync();
        }
    }
}
