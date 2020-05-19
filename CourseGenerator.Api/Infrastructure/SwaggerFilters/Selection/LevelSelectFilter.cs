using CourseGenerator.Api.Models.Selection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Selection
{
    /// <summary>
    /// Додає приклад для <see cref="LevelSelectModel"/>
    /// </summary>
    public class LevelSelectFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "Number", new OpenApiInteger(3) },
                { "Name", new OpenApiString("Advanced") }
            };
        }
    }
}
