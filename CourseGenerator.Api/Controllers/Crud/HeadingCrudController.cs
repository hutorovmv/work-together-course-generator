using AutoMapper;
using CourseGenerator.Api.Controllers.Generic;
using CourseGenerator.Api.Models.Entities;
using CourseGenerator.BLL.DTO.Entities;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

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

        public override async Task<IActionResult> CreateAsync(HeadingModel model)
        {
            HeadingDTO dto = _mapper.Map<HeadingDTO>(model);

            int? id = await (_crudService as IHeadingServiceUpgrade)
                .CreateAsync(UserId, dto);
            
            if (id.HasValue)
                return StatusCode(StatusCodes.Status201Created, id);

            return BadRequest();
        }
    }
}
