using CourseGenerator.Api.Infrastructure.SwaggerFilters.Locals;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Models.Locals
{
    /// <summary>
    /// ViewModel, для локалізованої частини
    /// сутності - Рубрика
    /// </summary>
    [SwaggerSchemaFilter(typeof(HeadingLangFilter))]
    public class HeadingLangModel
    {
        /// <summary>
        /// Ідентифікатор рубрики
        /// </summary>
        public int HeadingId { get; set; }

        /// <summary>
        /// Мова локалізації
        /// </summary>
        public string LangCode { get; set; }

        /// <summary>
        /// Локалізована назва рубрики
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Локалізований опис рубрики
        /// </summary>
        public string Description { get; set; }
    }
}
