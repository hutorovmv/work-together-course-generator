using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
