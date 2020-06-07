using CourseGenerator.Models.Entities.CourseAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IMaterialManagerRepository: IRepository<MaterialManager>, IAccessManager<MaterialManager>
    {

    }
}
