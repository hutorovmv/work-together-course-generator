using CourseGenerator.BLL.DTO;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples
{
    /// <summary>
    /// Додає приклад для <see cref="LevelSelectDTO"/>
    /// </summary>
    public class LevelSelectSchemaFilter : ISchemaFilter
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
