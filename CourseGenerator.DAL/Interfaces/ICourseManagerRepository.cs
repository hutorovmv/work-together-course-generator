using CourseGenerator.Models.Entities.CourseAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Interfaces
{
    public interface ICourseManagerRepository: IRepository<CourseManager>, IAccess<CourseManager>
    {

    }
}
