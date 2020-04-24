using CourseGenerator.BLL.DTO;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Infrastructure.SwaggerFilters.Examples
{
    /// <summary>
    /// Додає приклад для <see cref="UserLoginDTO"/>
    /// </summary>
    public class UserLoginSchemaFilter : ISchemaFilter
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
