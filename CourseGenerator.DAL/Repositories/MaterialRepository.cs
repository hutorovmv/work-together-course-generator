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

        public Task<IEnumerable<MaterialLang>> GetChildrenLocalAsync(int id, string langCode)
        {
            //IQueryable<Material> materialsChild = _context.Materials
            //    .Include(m => m.MaterialBlocksChild)
            //    .Select(mc => mc.MaterialBlocksChild
            //    .Where(mc => mc.ParentId == id));

            //return await materialsChild.Include(mc => mc.MaterialLangs)
            //.Select(ml => ml.MaterialLangs
            //.Where (ml => ml.LangCode == langCode)).ToListAsync();

            //IQueryable<int> childMaterial = _context.MaterialBlocks
            //    .Where(cm => cm.ChildId == id)
            //    .Select(cm => cm.ChildId);

            //return await _context.MaterialLangs
            //    .Where(cml => cml.LangCode == langCode && childMaterial.Contains(cml.MaterialId)).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<MaterialLang> GetParentsLocalAsync(int id, string langCode)
        {

            Material parentMaterial = await _context.MaterialBlocks
                .Where(mb => mb.ParentId == id)
                .Select(mb => mb.ParentMaterial).FirstOrDefaultAsync();

            MaterialLang localMaterial = await _context.MaterialLangs
                .Where(ml => ml.LangCode == langCode 
                && ml.MaterialId == parentMaterial.Id).FirstOrDefaultAsync();

            if (localMaterial == null)
            {
                return await _context.MaterialLangs
                    .Where(ml => ml.MaterialId == parentMaterial.Id).FirstOrDefaultAsync();
            }

            return localMaterial;

        }

        public Task<IEnumerable<MaterialLang>> GetRootLocalAsync(string langCode)
        {
            //IQueryable<MaterialBlock> materialParent = _context.Materials
            //    .Include(m => m.MaterialBlocksParent)
            //    .Where(m => m.MaterialBlocksParent)

            throw new NotImplementedException();
        }
    }
}
