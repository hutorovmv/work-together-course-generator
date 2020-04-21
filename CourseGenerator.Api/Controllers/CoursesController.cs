using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseGenerator.BLL.DTO;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.DAL.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseSelectDTO>> GetCoursesForUserWithLang(string langCode)
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<CourseSelectDTO> courseSelectDTOs = await _courseService
                .GetUserCoursesLocalizedAsync(userId, langCode);

            return courseSelectDTOs;
        }
    }
}