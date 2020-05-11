using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerExamples.Security
{
    /// <summary>
    /// Додає приклад для <see cref="PhoneAuthModel"/>
    /// </summary>
    public class PhoneAuthFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "PhoneNumber", new OpenApiString("380638888888") },
                { "Code", new OpenApiString("499591") }
            };
        }
    }
}
