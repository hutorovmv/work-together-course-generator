using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples
{
    /// <summary>
    /// Додає приклад для <see cref="CodeAuthModel"/>
    /// </summary>
    public class CodeAuthSchemaFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "UserId", new OpenApiString("8538cc1d-93c9-4bfa-966d-fbcef2a407f9") },
                { "Code", new OpenApiString("cffb56a6-260a-4e0a-831b-3bed6adc3d74") }
            };
        }
    }
}
