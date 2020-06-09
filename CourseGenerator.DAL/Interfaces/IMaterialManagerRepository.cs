using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IMaterialManagerRepository: IRepository<MaterialManager>, IAccessManager<MaterialManager>
    {

    }
}
