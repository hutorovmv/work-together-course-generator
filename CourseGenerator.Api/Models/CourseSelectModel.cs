using CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє курс в меню вибору курсу
    /// </summary>
    [SwaggerSchemaFilter(typeof(CourseSelectSchemaFilter))]
    public class CourseSelectModel
    {
        /// <summary>
        /// Код курсу.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва курсу.
        /// </summary>
        public string Name { get; set; }
    }
}
