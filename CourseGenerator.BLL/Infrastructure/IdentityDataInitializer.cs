using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using AutoMapper;

namespace CourseGenerator.BLL.Infrastructure
{
    public static class IdentityDataInitializer
    {
        public static void AddData(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            AddRoles(roleManager);
            AddAdmin(userManager, mapper);
        }

        public static void AddRoles(RoleManager<Role> roleManager)
        {
            string[] roles = { "Admin", "ContentAdmin", "ContentManager", "User" };

            foreach (var role in roles)
            {
                bool exists = roleManager.RoleExistsAsync(role).Result;
                if (!exists)
                    roleManager.CreateAsync(new Role(role)).Wait();
            }
        }

        public static void AddAdmin(UserManager<User> userManager, IMapper mapper)
        {
            UserRegistrationDTO adminDto = new UserRegistrationDTO
            {
                Email = "admin_email@example.com",
                FirstName = "FirstName",
                LastName = "LastName",
                Password = "Adm1nU5er!"
            };

            User admin = userManager.FindByNameAsync(adminDto.Email).Result;
            if (admin != null)
                return;

            admin = new User();
            admin = mapper.Map<User>(adminDto);

            IdentityResult result = userManager.CreateAsync(admin, adminDto.Password).Result;
            if (!result.Succeeded)
                return;

            userManager.AddToRolesAsync(admin, new string[] { "Admin", "ContentAdmin", "User" }).Wait();
        }
    }
}
