using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.CourseAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingManagerRepository: GenericEFRepository<HeadingManager>, IHeadingManagerRepository
    {
        public HeadingManagerRepository(ApplicationContext context): base(context)
        {
        }
    }
}
