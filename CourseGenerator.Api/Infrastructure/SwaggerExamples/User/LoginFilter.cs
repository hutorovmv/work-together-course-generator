using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseGenerator.Api.Infrastructure.SwaggerExamples.User
{
    /// <summary>
    /// Додає приклад для <see cref="UserLoginModel"/>
    /// </summary>
    public class LoginFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "UserName", new OpenApiString("andrewryzhkov@gmail.com") },
                { "Password", new OpenApiString("Andruha123!") }
            };
        }
    }
}
