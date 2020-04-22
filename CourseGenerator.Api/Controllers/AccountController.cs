using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using CourseGenerator.BLL.Interfaces;
using CourseGenerator.BLL.Infrastructure;
using CourseGenerator.BLL.DTO;
using CourseGenerator.Models.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using CourseGenerator.Api.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using CourseGenerator.Models.Entities.Security;

namespace CourseGenerator.Api.Controllers
{
    [Route("~/api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly AuthOptions _authOptions;

        public AccountController(IUserManagementService userManagementService,
            AuthOptions authOptions)
        {
            _userManagementService = userManagementService;
            _authOptions = authOptions;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRegistrationDTO registrationDto)
        {
            OperationInfo registrationResult = await _userManagementService
                .CreateAsync(registrationDto, "User");
            if (registrationResult.Succeeded)
                return StatusCode(StatusCodes.Status201Created);
            return BadRequest(registrationDto);
        }

        [Route("~/api/[controller]/confirm/phone")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GeneratePhoneNumberConfirmationCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);

            string userName = HttpContext.User.Identity.Name;
            UserDetailsDTO userDetailsDto = await _userManagementService
                .GetDetailsByUserNameAsync(userName);

            if (userDetailsDto.PhoneNumber == null)
                return BadRequest("User don't have phone number");

            PhoneAuth phoneAuth = new PhoneAuth
            {
                PhoneNumber = userDetailsDto.PhoneNumber,
                Code = Convert.ToString(code)
            };
            await _userManagementService.CreatePhoneNumberConfirmationCodeAsync(phoneAuth);

            return Ok(phoneAuth.Code);
        }

        [Route("~/api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO loginDto)
        {
            ClaimsIdentity identity = await _userManagementService.GetIdentityAsync(loginDto);
            if (identity == null)
                return Unauthorized(loginDto);

            var response = new
            {
                access_token = CreateToken(identity),
                userId = identity.FindFirst(ClaimTypes.NameIdentifier),
                username = identity.Name,
                firstName = identity.FindFirst(ClaimTypes.GivenName),
                lastName = identity.FindFirst(ClaimTypes.Surname),
                langCode = identity.FindFirst(ClaimTypes.Locality)
            };

            return Ok(response);
        }

        [Route("~/api/[controller]/authenticate/phone")]
        [HttpPost]
        public async Task<IActionResult> AuthenticateWithBot([FromBody] PhoneAuth phoneAuth)
        {
            ClaimsIdentity identity = await _userManagementService.GetIdentityAsync(phoneAuth);
            if (identity == null)
                return Unauthorized($"Code \"{phoneAuth.Code}\" is invalid.");

            var response = new
            {
                access_token = CreateToken(identity),
                username = identity.Name
            };

            return Ok(response);
        }

        private string CreateToken(ClaimsIdentity identity)
        {
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddDays(_authOptions.Lifetime),
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}