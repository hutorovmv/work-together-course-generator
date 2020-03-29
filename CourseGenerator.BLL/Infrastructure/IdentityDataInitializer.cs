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
        /// <summary>
        /// Додає ролі в базу даних
        /// </summary>
        /// <param name="roleManager">Identity <c>RoleManager</c> для <c>Role</c> або похідний від нього</param>
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

        /// <summary>
        /// Додає адміна в базу даних
        /// </summary>
        /// <param name="userManager">Identity <c>UserManager</c> для <c>User</c> або похідний від нього</param>
        /// <param name="mapper">Мепер для створення <c>User</c> з <c>UserRegistrationDTO</c></param>
        /// <param name="adminDto">Об'єкт передачі даних для реєстрації</param>
        /// <remarks>
        /// <para>
        /// Дані адміна передаються через параметер для можливості зберігання їх в <c>user-secrets</c> в проекті WebApi.
        /// <c>UserRegistrationDTO</c> використаний, бо необхідна можливість передати пароль.
        /// </para>
        /// </remarks>
        public static void AddAdmin(UserManager<User> userManager, IMapper mapper, UserRegistrationDTO adminDto)
        {
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
