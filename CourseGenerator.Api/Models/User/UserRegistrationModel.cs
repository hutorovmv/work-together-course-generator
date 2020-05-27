using CourseGenerator.Api.Infrastructure.SwaggerFilters.User;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models.User
{
    /// <summary>
    /// ViewModel, дані для реєстрації користувача
    /// </summary>
    [SwaggerSchemaFilter(typeof(RegistrationFilter))]
    public class UserRegistrationModel
    {
        /// <summary>
        /// Електронна адреса
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Номер телефону
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ім'я
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Прізвище
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Дата народження
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Код мови, зручної користувачу
        /// </summary>
        [Required]
        public string PreferedLangCode { get; set; }

        /// <summary>
        /// Пароль для входу в аккаунт
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Підтвердження пароля
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
    }
}
