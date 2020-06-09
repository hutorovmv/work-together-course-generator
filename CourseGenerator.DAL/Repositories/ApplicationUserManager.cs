using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Pagination;
using CourseGenerator.Models.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, 
            IEnumerable<IUserValidator<User>> userValidators, 
            IEnumerable<IPasswordValidator<User>> passwordValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            IServiceProvider services, 
            ILogger<UserManager<User>> logger) : base(
                store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators, 
                keyNormalizer, 
                errors, 
                services, 
                logger)
        {
            
        }
        public async Task<bool> IsAdmin(string userId)
        {
            User user = await FindByIdAsync(userId);
            return await IsInRoleAsync(user, "Admin");
        }

        public async Task<bool> IsContentAdmin(string userId)
        {
            User user = await FindByIdAsync(userId);
            return await IsInRoleAsync(user, "ContentAdmin");
        }

        public async Task<bool> IsContentManager(string userId)
        {
            User user = await FindByIdAsync(userId);
            return await IsInRoleAsync(user, "ContentManager");
        }

        public async Task<bool> IsUser(string userId)
        {
            User user = await FindByIdAsync(userId);
            return await IsInRoleAsync(user, "User");
        }

        /// <summary>
        /// Шукає користувача за номером телефону.
        /// </summary>
        /// <param name="phoneNumber">Номер телефону потрібного користувача</param>
        /// <returns>Користувач, асоційований з цим номером</returns>
        /// <remarks>
        /// <para>
        /// Необхідно впевнитись, що сутність <c>User</c> налаштована так, що
        /// кожен користувач має унікальний номер телефону.
        /// </para>
        /// <para>
        /// Якщо існує 2 користувача з таким номером то буде повернуто <c>null</c>.
        /// </para>
        /// </remarks>
        public async Task<User> FindByPhoneNumberAsync(string phoneNumber)
        {
            if (Users.Where(p => p.PhoneNumber == phoneNumber).Count() > 1)
                return null;

            return await Users.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        }

        public async Task<PagedList<User>> FilterPagedAsync(string name, string surname, 
            string userName, string roleId, int pageSize, int pageIndex)
        {
            IQueryable<User> users = Users;

            if (name != null)
                users = users.Where(u => u.FirstName.StartsWith(name));
            if(surname != null)
                users = users.Where(u => u.LastName.StartsWith(surname));
            if(userName != null)
                users = users.Where(u => u.UserName.StartsWith(userName));

            if(roleId != null)
            {
                var usersStore = Store as UserStore<User>;
                var context = usersStore.Context as IdentityDbContext<User>;
                IQueryable<string> usersInRoleIds = context.UserRoles
                    .Where(ur => ur.RoleId == roleId)
                    .Select(ur => ur.UserId);
                
                users = users.Where(u => usersInRoleIds.Contains(u.Id));
            }

            return await users.ToPagedListAsync(pageSize, pageIndex);
        }
    }
}
