using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class MaterialLangRepository: GenericEFRepository<MaterialLang>, IRepository<MaterialLang>
    {
        public MaterialLangRepository(ApplicationContext context): base(context){}
    }
}
