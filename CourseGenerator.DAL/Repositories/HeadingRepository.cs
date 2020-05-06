using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingRepository : GenericEFRepository<Heading>, IHeadingRepository
    {
        public HeadingRepository(ApplicationContext context) : base(context)
        {
        }


    }
}
