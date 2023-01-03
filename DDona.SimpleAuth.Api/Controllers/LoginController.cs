using DDona.SimpleAuth.Domain.DTO.User;
using DDona.SimpleAuth.Application.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DDona.SimpleAuth.Application.Services.Interfaces;
using DDona.SimpleAuth.Application.Models.AppSettings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using DDona.SimpleAuth.Domain.Constants;

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

            var token = await _AuthenticationService.GenerateToken(request.Email);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpGet("secured-administrator")]
        [Authorize(Roles = UserRolesConstants.Administrator)]
        public async Task<IActionResult> Secured()
        {
            return Ok("you are worthy, administrator");
        }

        [HttpGet("secured-worker")]
        [Authorize(Roles = $"{UserRolesConstants.Administrator},{UserRolesConstants.Worker}")]
        public async Task<IActionResult> SecuredWorker()
        {
            return Ok("Hm, either you are administrator or worker.");
        }

        [HttpPost("create-user")]
        [Authorize(Roles = UserRolesConstants.Administrator)]
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
