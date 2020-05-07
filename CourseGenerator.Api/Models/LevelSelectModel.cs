using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє рівень в меню вибору рівня
    /// </summary>
    [SwaggerSchemaFilter(typeof(LevelSelectSchemaFilter))]
    public class LevelSelectModel
    {
        /// <summary>
        /// Номер рівня.
        /// </summary>
        [Required]
        [DefaultValue(1)]
        public int Number { get; set; }

        /// <summary>
        /// Локалізована назва рівня.
        /// </summary>
        public string Name { get; set; }
    }
}
