using CourseGenerator.Api.Models.Locals;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Locals
{
    /// <summary>
    /// Додає приклад для <see cref="HeadingLangModel"/>
    /// </summary>
    [SwaggerSchemaFilter(typeof(HeadingLangFilter))]
    public class HeadingLangFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "HeadingId", new OpenApiInteger(1) },
                { "LangCode", new OpenApiString("ua") },
                { "Name", new OpenApiString("Алгоритми") },
                { "Description", new OpenApiString("У цій рубриці знаходяться" +
                " статті та матеріали про алгоритмізацію") }
            };
        }
    }
}
