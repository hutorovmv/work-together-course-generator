using CourseGenerator.Api.Models.Entities;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Entities
{
    /// <summary>
    /// Додає приклад для <see cref="HeadingModel"/>
    /// </summary>
    [SwaggerSchemaFilter(typeof(HeadingFilter))]
    public class HeadingFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "Id", new OpenApiInteger(3) },
                { "Code", new OpenApiString("1.1.1") },
                { "UDC", new OpenApiString("1.1.1") },
                { "Note", new OpenApiString("Some text here") }
            };
        }
    }
}