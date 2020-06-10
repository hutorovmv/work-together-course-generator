using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using System.Linq;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingManagerRepository : GenericEFRepository<HeadingManager>, 
        IHeadingManagerRepository
    {
        public HeadingManagerRepository(ApplicationContext context) 
            : base(context) 
        {
        }

        public bool HasAccess(string userId, params object[] id)
        {
            return _context.HeadingManagers
                .ToList()
                .Any(uh => new object[] { uh.HeadingId }  == id 
                    && uh.UserId == userId);
        }
    }
}
