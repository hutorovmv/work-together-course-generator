using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.DAL.Context;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UserManager<User> UserManager { get; set; }
        public RoleManager<Role> RoleManager { get; set; }

        public UnitOfWork(ApplicationContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            _context = context;

            UserManager = userManager;
            RoleManager = roleManager;
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
