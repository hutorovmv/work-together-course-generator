using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerExamples.Selection
{
    /// <summary>
    /// Додає приклад для <see cref="CourseSelectModel"/>
    /// </summary>
    public class CourseSelectFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "Id", new OpenApiInteger(1) },
                { "Name", new OpenApiString("ASP.Net Core") }
            };
        }
    }
}
