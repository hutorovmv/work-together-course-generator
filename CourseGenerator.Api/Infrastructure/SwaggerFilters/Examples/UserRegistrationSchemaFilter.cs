using CourseGenerator.Api.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples
{
    /// <summary>
    /// Додає приклад для <see cref="UserRegistrationModel"/>
    /// </summary>
    public class UserRegistrationSchemaFilter : ISchemaFilter
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
                { "PreferedLangCode", new OpenApiString("eng") },
                { "Password", new OpenApiString("12345678") },
                { "PasswordConfirm", new OpenApiString("12345678") }
            };
        }
    }
}
