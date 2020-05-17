using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CourseGenerator.Api.Infrastructure.SwaggerExamples.User
{
    /// <summary>
    /// Додає приклад для <see cref="UserSettingsModel"/>
    /// </summary>
    public class UserSettingsFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "FirstName", new OpenApiString("Mykola") },
                { "LastName", new OpenApiString("Hutorov") },
                { "BirthDate", new OpenApiDate(new DateTime(2001, 2, 16)) },
                { "PreferedLangCode", new OpenApiString("eng") }
            };
        }
    }
}
