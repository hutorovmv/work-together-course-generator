using CourseGenerator.Api.Infrastructure.SwaggerFilters.User;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace CourseGenerator.Api.Models.User
{
    /// <summary>
    /// ViewModel, що представляє об'єкт для налаштувань користувача
    /// </summary>
    [SwaggerSchemaFilter(typeof(UserSettingsFilter))]
    public class UserSettingsModel
    {
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
        /// Код мови користувача
        /// </summary>
        public string PreferedLangCode { get; set; }
    }
}
