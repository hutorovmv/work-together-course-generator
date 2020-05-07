using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public ApplicationUserManager UserManager { get; set; }
        public RoleManager<Role> RoleManager { get; set; }     
        public IRepository<Language> LanguageRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public IRepository<UserCourse> UserCourseRepository { get; set; }
        public IPhoneAuthRepository PhoneAuthRepository { get; set; }
        public IThemeRepository ThemeRepository { get; set; }
        public IHeadingRepository HeadingRepository { get; set; }
        public ICodeAuthRepository CodeAuthRepository { get; set; }

        public UnitOfWork(ApplicationContext context,
            ApplicationUserManager userManager,
            RoleManager<Role> roleManager,
            ICourseRepository courseRepository,
            IRepository<UserCourse> userCourseRepository,
            IPhoneAuthRepository phoneAuthRepository,
            IThemeRepository themeRepository,
            IHeadingRepository headingRepository,
            ICodeAuthRepository codeAuthRepository,
            IRepository<Language> languageRepository)
        {
            _context = context;

            UserManager = userManager;
            RoleManager = roleManager;
            ThemeRepository = themeRepository;
            CourseRepository = courseRepository;
            UserCourseRepository = userCourseRepository;
            PhoneAuthRepository = phoneAuthRepository;
            LanguageRepository = languageRepository;
            HeadingRepository = headingRepository;
            CodeAuthRepository = codeAuthRepository;
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
                UserCourseRepository.Dispose();
                HeadingRepository.Dispose();
                CodeAuthRepository.Dispose();
                PhoneAuthRepository.Dispose();

            }
            disposed = true;
        }
    }
}
