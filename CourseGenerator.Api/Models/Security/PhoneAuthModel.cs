using CourseGenerator.Api.Infrastructure.SwaggerFilters.Security;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models.Security
{
    /// <summary>
    /// ViewModel, що представляє об'єкт для автентифікації
    /// через телефон
    /// </summary>
    [SwaggerSchemaFilter(typeof(PhoneAuthFilter))]
    public class PhoneAuthModel
    {
        /// <summary>
        /// Номер телефону користувача.
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Код підтвердження.
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}
