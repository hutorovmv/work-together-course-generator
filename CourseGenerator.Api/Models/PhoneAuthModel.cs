using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє об'єкт для автентифікації
    /// через телефон
    /// </summary>
    [SwaggerSchemaFilter(typeof(PhoneAuthSchemaFilter))]
    public class PhoneAuthModel
    {
        /// <summary>
        /// Номер телефону користувача.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Код підтвердження.
        /// </summary>
        public string Code { get; set; }
    }
}
