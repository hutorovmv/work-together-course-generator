using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class UserCourseRepository: GenericEFRepository<UserCourse>, IUserCoursesRepository
    {
        public UserCourseRepository(ApplicationContext context) : base(context) {}

        public bool HasAcces(string userId, int courseId)
        {
            return _context.UserCourses
                .Any(uc => uc.UserId == userId && uc.CourseId == courseId);
        }
    }
}
