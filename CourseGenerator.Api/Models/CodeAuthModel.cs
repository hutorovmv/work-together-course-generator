using CourseGenerator.Api.Infrastructure.SwaggerExamples.Security;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє об'єкт для автентифікації
    /// через телефон
    /// </summary>
    [SwaggerSchemaFilter(typeof(CodeAuthFilter))]
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
