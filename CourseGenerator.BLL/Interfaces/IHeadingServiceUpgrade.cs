using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IHeadingServiceUpgrade : ICrudService<Heading, HeadingDTO>, 
        ICrudLocalService<HeadingLang, HeadingLangDTO>,
        IHierarchyLocalService<string, HeadingLang, HeadingSelectDTO>,
        IManagerAccessService<HeadingManager, HeadingManagerDTO>
    {
        Task<int?> CreateAsync(string userId, HeadingDTO dto,
            string parentCode = null);
    }
}
