using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що містить дані для автентифікації користувача
    /// </summary>
    [SwaggerSchemaFilter(typeof(UserLoginSchemaFilter))]
    public class UserLoginModel
    {
        /// <summary>
        /// Ім'я користувача
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль для входу в аккаунт
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
