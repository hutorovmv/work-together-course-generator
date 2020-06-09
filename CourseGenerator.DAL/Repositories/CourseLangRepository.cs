using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class CourseLangRepository : GenericEFRepository<CourseLang>, IRepository<CourseLang>
    {
        public CourseLangRepository(ApplicationContext context) : base(context){}
    }
}
