using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IHeadingRepository : IRepository<Heading>
    {
        string GetLastCode(string code);
    }
}
