using DDona.SimpleAuth.Api.Models.AppSettings;
using DDona.SimpleAuth.Domain.DTO.User;
using DDona.SimpleAuth.Application.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DDona.SimpleAuth.Application.Services.Interfaces;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _AuthenticationService;
        private readonly JwtBearerConfiguration _JwtBearerConfiguration;

        public LoginController(IAuthenticationService authenticationService, IOptions<JwtBearerConfiguration> jwtBearerConfigurationOptions)
        {
            _AuthenticationService = authenticationService;
            _JwtBearerConfiguration = jwtBearerConfigurationOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO request)
        {
            if (!await _AuthenticationService.AuthenticateUser(request.Email, request.Password))
                return BadRequest("Failed to authenticate");

            return Ok(await _AuthenticationService.GetUserRolesAsync(request.Email));        
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = new ApplicationUser
            {
                UserName = createUserDTO.Email,
                Email = createUserDTO.Email,
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,
                Inactive = false,
                LockoutEnabled = false
            };

            var result = await _AuthenticationService.CreateAsync(user, createUserDTO.Password);
            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
