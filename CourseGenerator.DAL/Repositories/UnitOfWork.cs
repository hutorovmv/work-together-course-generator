using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public ApplicationUserManager UserManager { get; set; }
        public RoleManager<Role> RoleManager { get; set; }

        public ICourseRepository CourseRepository { get; set; }
        public IRepository<UserCourse> UserCourseRepository { get; set; }

        public UnitOfWork(ApplicationContext context,
            ApplicationUserManager userManager,
            RoleManager<Role> roleManager,
            ICourseRepository courseRepository,
            IRepository<UserCourse> userCourseRepository)
        {
            _context = context;

            UserManager = userManager;
            RoleManager = roleManager;
            CourseRepository = courseRepository;
            UserCourseRepository = userCourseRepository;
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
            }
            disposed = true;
        }
    }
}
