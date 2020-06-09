using CourseGenerator.Api.Infrastructure.SwaggerFilters.User;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace CourseGenerator.Api.Models.User
{
    /// <summary>
    /// ViewModel, що містить дані користувача.
    /// </summary>
    [SwaggerSchemaFilter(typeof(UserFilter))]
    public class UserModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Адреса електронної пошти
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефону
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ім'я
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Прізвище
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Фото користувача
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Дата народження
        /// </summary>
        public DateTime? BirthDate { get; set; }
    }
}
