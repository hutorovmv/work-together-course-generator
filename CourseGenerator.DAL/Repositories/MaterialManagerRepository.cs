using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class MaterialManagerRepository: GenericEFRepository<MaterialManager>, IMaterialManagerRepository
    {
        public MaterialManagerRepository(ApplicationContext context): base(context){}

        public bool HasAccess(string userId, int materialId)
        {
            return _context.MaterialManagers
                .Any(mm => mm.MaterialId == materialId && mm.UserId == userId);
        }
    }
}
