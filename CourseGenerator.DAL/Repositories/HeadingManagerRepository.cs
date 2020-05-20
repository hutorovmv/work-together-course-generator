using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingManagerRepository: GenericEFRepository<HeadingManager>, IHeadingManagerRepository
    {
        public HeadingManagerRepository(ApplicationContext context): base(context){}

        public bool HasAcces(string userId, int headingId)
        {
            return _context.HeadingManagers
                .Any(uh => uh.HeadingId == headingId && uh.UserId == userId);

        }
    }
}
