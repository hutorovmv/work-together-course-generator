using CourseGenerator.Api.Models.User;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.User
{
    /// <summary>
    /// Додає приклад для <see cref="UserModel"/>
    /// </summary>
    public class UserFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject
            {
                { "Email", new OpenApiString("mykolahutorov@gmail.com") },
                { "PhoneNumber", new OpenApiString("380631111111") },
                { "FirstName", new OpenApiString("Mykola") },
                { "LastName", new OpenApiString("Hutorov") },
                { "BirthDate", new OpenApiDate(new DateTime(2001, 2, 16)) },
            };
        }
    }
}
