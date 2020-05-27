using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class HeadingLangRepository : GenericEFRepository<HeadingLang>, IRepository<HeadingLang>
    {
        public HeadingLangRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
