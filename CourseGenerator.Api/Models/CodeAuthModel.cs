using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє об'єкт для автентифікації
    /// через телефон
    /// </summary>
    [SwaggerSchemaFilter(typeof(CodeAuthSchemaFilter))]
    public partial class CodeAuthModel
    {
        /// <summary>
        /// Id користувача.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Унікальний код для аутентифікації.
        /// </summary>
        public string Code { get; set; }
    }
}
