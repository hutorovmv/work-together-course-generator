using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Locals;
using CourseGenerator.BLL.DTO.Locals;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers.CrudLocal
{
    [Route("api/headings")]
    //[ApiExplorerSettings(GroupName = "Heading")]
    [SwaggerTag("Контролер для роботи з локалізованими частинами рубрик")]
    public class HeadingCrudLocalController
        : CrudLocalController<HeadingLangModel, HeadingLangDTO>
    {
        public HeadingCrudLocalController(IMapper mapper, 
            IHeadingServiceUpgrade localCrudService) : base(mapper, localCrudService)
        {
        }
    }
}