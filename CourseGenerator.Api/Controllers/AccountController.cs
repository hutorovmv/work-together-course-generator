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

        [Route("~/api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO loginDto)
        {
            var identity = await _userManagementService.GetIdentityAsync(loginDto.UserName, 
                loginDto.Password);
            if (identity == null)
                return Unauthorized(loginDto);

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
            string encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            var response = new
            {
                access_token = encodedToken,
                username = identity.Name
            };

            return Ok(response);
        }

        [Route("~/api/[controller]/[action]")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GeneratePhoneNumberConfirmationCode()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);

            string userName = HttpContext.User.Identity.Name;
            UserDetailsDTO userDetailsDto = await _userManagementService
                .GetDetailsByUserNameAsync(userName);

            var phoneNumberConfirmDict = new Dictionary<string, string>();
            phoneNumberConfirmDict["PhoneNumber"] = userDetailsDto.PhoneNumber;
            phoneNumberConfirmDict["Code"] = Convert.ToString(code);

            string phoneNumberConfirmSerialized = JsonConvert
                .SerializeObject(phoneNumberConfirmDict);
            HttpContext.Session
                .SetString("PhoneNumberConfirmationData", phoneNumberConfirmSerialized);
            return Ok(phoneNumberConfirmDict["Code"]);
        }

        [Route("~/api/[controller]/[action]")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmPhoneNumberWithCode([FromBody] string code)
        {
            var validPhoneNumberConfirmSerialized = HttpContext.Session
                .GetString("PhoneNumberConfirmationData");

            if (validPhoneNumberConfirmSerialized == null)
                return BadRequest("Code has not been generated.");

            var validPhoneNumberConfirmDict = JsonConvert
                .DeserializeObject<Dictionary<string, string>>(validPhoneNumberConfirmSerialized);

            string userName = HttpContext.User.Identity.Name;
            UserDetailsDTO userDetailsDto = await _userManagementService
                .GetDetailsByUserNameAsync(userName);

            if (validPhoneNumberConfirmDict["PhoneNumber"] == userDetailsDto.PhoneNumber 
                && validPhoneNumberConfirmDict["Code"] == code)
            {
                OperationInfo phoneConfirmationResult = await _userManagementService
                    .ConfirmPhoneNumberAsync(userName);

                if (phoneConfirmationResult.Succeeded)
                    return Ok(phoneConfirmationResult.Message);
                else
                    return BadRequest(phoneConfirmationResult.Message);
            }

            return BadRequest("Code is invalid or phone number has changed.");
        }
    }
}