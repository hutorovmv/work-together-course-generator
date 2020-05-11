using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerExamples.Selection
{
    /// <summary>
    /// Додає приклад для <see cref="UserThemeSelectModel"/>
    /// </summary>
    public class UserThemeSelectFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "Id", new OpenApiInteger(4) },
                { "Name", new OpenApiString("Пошукові алгоритми") },
                { "IsCompleted", new OpenApiBoolean(false) }
            };
        }
    }
}
