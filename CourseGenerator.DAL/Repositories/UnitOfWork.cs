using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public ApplicationUserManager UserManager { get; set; }
        public RoleManager<Role> RoleManager { get; set; }
        public IRepository<Language> LanguageRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IRepository<CourseLang> CourseLangRepository { get; set; }
        public IPhoneAuthRepository PhoneAuthRepository { get; set; }
        public IThemeRepository ThemeRepository { get; set; }
        public IHeadingRepository HeadingRepository { get; set; }
        public ICodeAuthRepository CodeAuthRepository { get; set; }
        public IRepository<HeadingLang> HeadingLangRepository { get; set; }
        public IHeadingManagerRepository HeadingManagerRepository { get; set; }
        public IFileRepository FileRepository { get; set; }
        public IUserCoursesRepository UserCoursesRepository { get; set; }
        public IMaterialRepository MaterialRepository { get; set; }
        public IRepository<MaterialLang> MaterialLangRepository { get; set; }
        public ICourseManagerRepository CourseManagerRepository {get;set;}

        public UnitOfWork(ApplicationContext context,
            ApplicationUserManager userManager,
            RoleManager<Role> roleManager,
            ICourseRepository courseRepository,
            IPhoneAuthRepository phoneAuthRepository,
            IThemeRepository themeRepository,
            IHeadingRepository headingRepository,
            ICodeAuthRepository codeAuthRepository,
            IRepository<HeadingLang> headingLangRepository,
            IRepository<Language> languageRepository,
            IFileRepository fileRepository,
            IUserCoursesRepository userCoursesRepository,
            IMaterialRepository materialRepository,
            IRepository<MaterialLang> materialLangRepository,
            IHeadingManagerRepository headingManagerRepository,
            ICourseManagerRepository courseManagerRepository)
        {
            _context = context;

            UserManager = userManager;
            RoleManager = roleManager;
            ThemeRepository = themeRepository;
            CourseRepository = courseRepository;
            PhoneAuthRepository = phoneAuthRepository;
            LanguageRepository = languageRepository;
            HeadingRepository = headingRepository;
            CodeAuthRepository = codeAuthRepository;
            HeadingLangRepository = headingLangRepository;
            HeadingManagerRepository = headingManagerRepository;
            FileRepository = fileRepository;
            UserCoursesRepository = userCoursesRepository;
            MaterialRepository = materialRepository;
            MaterialLangRepository = materialLangRepository;
            CourseManagerRepository = courseManagerRepository;
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                UserManager.Dispose();
                RoleManager.Dispose();
                LanguageRepository.Dispose();
                CourseRepository.Dispose();
                ThemeRepository.Dispose();
                UserCoursesRepository.Dispose();
                HeadingRepository.Dispose();
                CodeAuthRepository.Dispose();
                PhoneAuthRepository.Dispose();
                HeadingLangRepository.Dispose();
                HeadingManagerRepository.Dispose();
                FileRepository.Dispose();
                UserCoursesRepository.Dispose();
                MaterialRepository.Dispose();
                MaterialLangRepository.Dispose();
                CourseManagerRepository.Dispose();
            }
            disposed = true;
        }
    }
}
