using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; set; }
        RoleManager<Role> RoleManager { get; set; }
        
        Task SaveAsync();
    }
}
