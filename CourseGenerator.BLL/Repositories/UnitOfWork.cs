using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseGenerator.DAL.Context;
using CourseGenerator.BLL.Interfaces;

namespace CourseGenerator.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
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
                // ...
            }
            disposed = true;
        }
    }
}
