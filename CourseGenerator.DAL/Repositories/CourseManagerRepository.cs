using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.DAL.Repositories
{
    public class CourseManagerRepository: GenericEFRepository<CourseManager>, ICourseManagerRepository
    {
        public CourseManagerRepository(ApplicationContext context) : base(context){}

        public bool HasAccess(string userId, params object[] id)
        {
            return _context.CourseManagers
                .Any(cm => new object[] { cm.CourseId } == id && cm.UserId == userId);
        }
    }
}
