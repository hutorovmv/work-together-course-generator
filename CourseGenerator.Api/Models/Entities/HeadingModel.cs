using CourseGenerator.Api.Infrastructure.SwaggerFilters.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Models.Entities
{
    /// <summary>
    /// ViewModel, для нелокалізованої частини
    /// сутності - Рубрика.
    /// </summary>
    [SwaggerSchemaFilter(typeof(HeadingFilter))]
    public class HeadingModel
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код для побудови ієрархії
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Код в універсальному десятковому класифікаторі
        /// </summary>
        public string UDC { get; set; }

        /// <summary>
        /// Примітка (для авторів контенту)
        /// </summary>
        public string Note { get; set; }
    }
}
