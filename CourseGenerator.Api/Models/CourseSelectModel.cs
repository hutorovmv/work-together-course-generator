using CourseGenerator.Api.Infrastructure.SwaggerExamples.Selection;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє курс в меню вибору курсу
    /// </summary>
    [SwaggerSchemaFilter(typeof(CourseSelectFilter))]
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
