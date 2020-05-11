using CourseGenerator.Api.Infrastructure.SwaggerExamples.Selection;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє тему в меню вибору теми
    /// </summary>
    [SwaggerSchemaFilter(typeof(UserThemeSelectFilter))]
    public class UserThemeSelectModel
    {
        /// <summary>
        /// Код теми.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва теми.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Чи пройдена тема користувачем.
        /// </summary>
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}
