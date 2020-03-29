using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.DAL.Repositories;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; set; }
        RoleManager<Role> RoleManager { get; set; }

        ICourseRepository CourseRepository { get; set; }

        Task SaveAsync();
    }
}
