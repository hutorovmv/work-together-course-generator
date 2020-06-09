using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
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

        public async Task<IEnumerable<MaterialLang>> GetChildrenLocalAsync(int id, string langCode)
        {
            IQueryable<MaterialLang> childMaterialLang= _context.MaterialLangs
                .Where(ml => ml.LangCode == langCode)
                .Include(ml => ml.Material)
                .ThenInclude(m => m.MaterialBlocksParent.Where(mb => mb.ParentId == id)
                .Select(mb => mb.ChildMaterial));

            if(childMaterialLang == null)
            {
                return await _context.MaterialLangs
                    .Include(ml => ml.Material)
                    .ThenInclude(m => m.MaterialBlocksParent.Where(mb => mb.ParentId == id)
                    .Select(mb => mb.ChildMaterial)).ToListAsync();
            }

            return await childMaterialLang.ToListAsync();

        }

        //public async Task<IEnumerable<MaterialLang>> GetParentsLocalAsync(int id, string langCode)
        //{

        //    Material parentMaterial = await _context.MaterialBlocks
        //        .Where(mb => mb.ParentId == id)
        //        .Select(mb => mb.ParentMaterial).FirstOrDefaultAsync();

        //    MaterialLang localMaterial = await _context.MaterialLangs
        //        .Where(ml => ml.LangCode == langCode 
        //        && ml.MaterialId == parentMaterial.Id).FirstOrDefaultAsync();

        //    if (localMaterial == null)
        //    {
        //        return await _context.MaterialLangs
        //            .Where(ml => ml.MaterialId == parentMaterial.Id).FirstOrDefaultAsync();
        //    }

        //    return localMaterial;

        //}

        public async Task<IEnumerable<MaterialLang>> GetParentsLocalAsync(int id, string langCode)
        {

            int? parentMaterialId = await _context.MaterialBlocks
                .Where(mb => mb.ChildId == id)
                .Select(mb => mb.ParentId).FirstOrDefaultAsync();

            int? higherParentId = await _context.MaterialBlocks
                .Where(mb => mb.ChildId == parentMaterialId)
                .Select(mb => mb.ParentId).FirstOrDefaultAsync();

            if (higherParentId == null)
                await GetRootLocalAsync(langCode);

            IQueryable<MaterialLang> localMaterial = _context.MaterialLangs
                .Where(ml => ml.LangCode == langCode)
                .Include(ml => ml.Material)
                .ThenInclude(ml => ml.MaterialBlocksParent.Where(mbp => mbp.ParentId == higherParentId)
                .Select(mbp => mbp.ChildMaterial));

            if (localMaterial == null)
            {
                return await _context.MaterialLangs
                .Include(ml => ml.Material)
                .ThenInclude(ml => ml.MaterialBlocksParent.Where(mbp => mbp.ParentId == higherParentId)
                .Select(mbp => mbp.ChildMaterial)).ToListAsync();
            }

            return await localMaterial.ToListAsync();

        }

        public async Task<IEnumerable<MaterialLang>> GetRootLocalAsync(string langCode)
        {

            //IQueryable<Material> rootMaterials = _context.MaterialBlocks
            //    .Where(m => m.ParentId == null)
            //    .Select(m => m.ParentMaterial);

            IQueryable<MaterialLang> materialLangs = _context.MaterialLangs
                .Where(rm => rm.LangCode == langCode)
                .Include(rm => rm.Material)
                .ThenInclude(m => m.MaterialBlocksParent.Where(p => p.ParentId == null)
                .Select(m => m.ParentMaterial));

            if(materialLangs == null)
            {
                return await _context.MaterialLangs
                    .Include(ml => ml.Material)
                    .ThenInclude(m => m.MaterialBlocksParent.Where(p => p.ParentId == null)
                    .Select(m => m.ParentMaterial)).ToListAsync();
            }

            return await materialLangs.ToListAsync();
        }
    }
}
