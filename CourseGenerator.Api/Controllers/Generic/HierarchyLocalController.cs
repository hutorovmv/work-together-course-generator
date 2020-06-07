using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CourseGenerator.BLL.Interfaces.Generic;
using CourseGenerator.BLL.Interfaces.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseGenerator.Api.Controllers.Generic
{
#pragma warning disable CS1591
    /// <summary>
    /// Контролер для локалізованої ієрархії, що працює з сервісом 
    /// </summary>
    /// <typeparam name="TViewModelHierarchy">
    /// ViewModel, з якою працює контролер
    /// </typeparam>
    /// <typeparam name="TId">Ідентифікатор для побудови ієрархії</typeparam>
    /// <typeparam name="TDTOHierarchy">DTO, з яким пряцює сервіс</typeparam>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json,
        new string[] { MediaTypeNames.Application.Xml })]
    public class HierarchyLocalController<TId, TViewModelHierarchy, 
        TDTOHierarchy> : ControllerBase
        where TViewModelHierarchy : class
        where TDTOHierarchy : class, ILocal
    {
        protected readonly IMapper _mapper;
        protected readonly IHierarchyLocalService<TId, object, TDTOHierarchy> 
            _localHierarchyService;

        protected string UserId => HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        public HierarchyLocalController(IMapper mapper,
            IHierarchyLocalService<TId, object, TDTOHierarchy> 
            localHierarchyService)
        {
            _mapper = mapper;
            _localHierarchyService = localHierarchyService;
        }

        /// <summary>
        /// Отримує локалізовані дані об'єктів сутності найвищого рівня
        /// вказаною мовою
        /// </summary>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Виконано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}/hierarchy/root")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetRootLocalAsync(string lang)
        {
            IEnumerable<TDTOHierarchy> dtos = await _localHierarchyService
                .GetRootLocalAsync(UserId, lang);
            
            IEnumerable<TViewModelHierarchy> models = _mapper
                .Map<IEnumerable<TViewModelHierarchy>>(dtos);
            
            return Ok(models);
        }

        /// <summary>
        /// Отримує локалізовані дані об'єктів сутності вищого рівня
        /// вказаною мовою
        /// </summary>
        /// <param name="id">Ідентифікатор для побудови ієрархії</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Виконано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}/hierarchy/parents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetParentsLocalAsync(TId id,
            string lang)
        {
            IEnumerable<TDTOHierarchy> dtos = await _localHierarchyService
                .GetParentsLocalAsync(UserId, lang, id);

            IEnumerable<TViewModelHierarchy> models = _mapper
                .Map<IEnumerable<TViewModelHierarchy>>(dtos);

            return Ok(models);
        }

        /// <summary>
        /// Отримує локалізовані дані об'єктів сутності нижчого рівня
        /// вказаною мовою
        /// </summary>
        /// <param name="id">Ідентифікатор для побудови ієрархії</param>
        /// <param name="lang">Код мови</param>
        /// <returns>Статус-код або повідомлення про помилку</returns>
        /// <response code="200">Виконано успішно</response>
        /// <response code="401">Неавторизовано</response>
        /// <response code="403">Заборонено</response>
        [HttpGet]
        [Route("{lang}/hierarchy/children")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetChildrenLocalAsync(TId id,
            string lang)
        {
            IEnumerable<TDTOHierarchy> dtos = await _localHierarchyService
                .GetChildrenLocalAsync(UserId, lang, id);

            IEnumerable<TViewModelHierarchy> models = _mapper
                .Map<IEnumerable<TViewModelHierarchy>>(dtos);

            return Ok(models);
        }
    }
    #pragma warning restore CS1591
}