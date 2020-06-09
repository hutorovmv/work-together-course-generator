using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Security;
using CourseGenerator.BLL.DTO.Security;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Interfaces.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CourseGenerator.Api.Controllers.Access
{
    [Route("api/headings/access/manager")]
    //[ApiExplorerSettings(GroupName = "Heading")]
    [SwaggerTag("Контролер для керування доступом до рубрик")]
    public class HeadingManagerAccessController
        : CrudController<HeadingManagerModel, HeadingManagerDTO>
    {
        public HeadingManagerAccessController(IMapper mapper, 
            IHeadingServiceUpgrade crudService) : base(mapper, 
                crudService as IManagerAccessService<object, HeadingManagerDTO>)
        {
        }
    }
}