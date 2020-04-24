using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, дані для реєстрації користувача
    /// </summary>
    [SwaggerSchemaFilter(typeof(UserRegistrationSchemaFilter))]
    public class UserRegistrationModel
    {
        /// <summary>
        /// Електронна адреса
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
        /// Дата народження
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Код мови, зручної користувачу
        /// </summary>
        public string PreferedLangCode { get; set; }

        /// <summary>
        /// Пароль для входу в аккаунт
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Підтвердження пароля
        /// </summary>
        public string PasswordConfirm { get; set; }
    }
}
