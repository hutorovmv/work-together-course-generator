using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CourseGenerator.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserManagementService _userManagementService;

        public AccountController(SignInManager<User> signInManager, IUserManagementService userManagementService)
        {
            _signInManager = signInManager;
            _userManagementService = userManagementService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegistrationDTO registrationDto)
        {
            OperationInfo registrationResult = await _userManagementService.CreateAsync(registrationDto);
            if (registrationResult.Succeeded)
                return StatusCode(StatusCodes.Status201Created);
            return BadRequest(registrationDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, false);
            if (signInResult.Succeeded)
                return Ok();
            return Unauthorized(loginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}