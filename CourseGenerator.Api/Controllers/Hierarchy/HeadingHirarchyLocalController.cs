using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Selection;
using CourseGenerator.BLL.DTO.Selection;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers.Hierarchy
{
    [Route("api/headings")]
    //[ApiExplorerSettings(GroupName = "Heading")]
    [SwaggerTag("Контролер для роботи з локалізованою ієрархією рубрик рубрик")]
    public class HeadingHirarchyLocalController
        : HierarchyLocalController<string, HeadingSelectModel, HeadingSelectDTO>
    {
        public HeadingHirarchyLocalController(IMapper mapper,
            IHeadingServiceUpgrade localHierarchyService) 
            : base(mapper, localHierarchyService)
        {
        }
    }
}