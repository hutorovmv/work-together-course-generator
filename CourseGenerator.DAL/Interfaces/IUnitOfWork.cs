using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.DAL.Repositories;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; set; }
        RoleManager<Role> RoleManager { get; set; }
        IRepository<Language> LanguageRepository { get; set; }
        IThemeRepository ThemeRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        IRepository<CourseLang> CourseLangRepository { get; set; }
        IPhoneAuthRepository PhoneAuthRepository { get; set; }
        IHeadingRepository HeadingRepository { get; set; }
        ICodeAuthRepository CodeAuthRepository { get; set; }
        IRepository<HeadingLang> HeadingLangRepository { get; set; }
        IHeadingManagerRepository HeadingManagerRepository { get; set; }
        IFileRepository FileRepository { get; set; }
        IUserCoursesRepository UserCoursesRepository { get; set; }
        IMaterialRepository MaterialRepository { get; set; }
        IRepository<MaterialLang> MaterialLangRepository { get; set; }

        Task SaveAsync();
    }
}
