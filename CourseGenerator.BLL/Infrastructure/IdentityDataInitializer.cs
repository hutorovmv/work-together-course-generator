using Microsoft.AspNetCore.Identity;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;

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
        public static void AddAdmin(IUserManagementService userManagementService, UserRegistrationDTO adminDto)
        {
            userManagementService.CreateAsync(adminDto, "Admin", "ContentAdmin", "User").Wait();
        }

        public static void AddTestUsersAndCourseAccessData(
            IUserManagementService userManagementService, 
            ICourseService courseService)
        {
            UserRegistrationDTO userRegistrationDto1 = new UserRegistrationDTO
            {
                Email = "andrewryzhkov@gmail.com",
                FirstName = "Andrew",
                LastName = "Ryzhkov",
                PhoneNumber = "380638888888",
                Password = "Andruha123!",
                PreferedLangCode = "eng"
            };
            userManagementService.CreateAsync(userRegistrationDto1, "User").Wait();

            UserDetailsDTO userDetailsDto1 = userManagementService.GetDetailsByNameAsync(userRegistrationDto1.Email).Result;
            courseService.AddUserToCourseAsync(userDetailsDto1.Id, 1, 1).Wait();
            courseService.AddUserToCourseAsync(userDetailsDto1.Id, 2, 1).Wait();
            courseService.AddUserToCourseAsync(userDetailsDto1.Id, 3, 1).Wait();
            courseService.AddUserToCourseAsync(userDetailsDto1.Id, 4, 1).Wait();
        }
    }
}
