using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers.Crud {
    [Route("api/headings")]
    //[ApiExplorerSettings(GroupName = "Heading")]
    [SwaggerTag("Контролер для роботи з нелокалізованими частинами рубрик")]
    public class HeadingCrudController 
        : CrudController<HeadingModel, HeadingDTO>
    {
        public HeadingCrudController(IMapper mapper, 
            IHeadingServiceUpgrade crudService) : base(mapper, crudService)
        {
        }
    }
}
