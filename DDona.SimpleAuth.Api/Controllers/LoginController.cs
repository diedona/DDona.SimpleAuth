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

            var roles = await _AuthenticationService.GetUserRolesAsync(request.Email);
            var claims = new List<Claim>() { new Claim(ClaimTypes.Sid, request.Email) };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GetToken(claims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpGet("secured")]
        [Authorize]
        public async Task<IActionResult> Secured()
        {
            return Ok("you are worthy");
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

        private JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtBearerConfiguration.Key));
            var minutesLifeTime = _JwtBearerConfiguration.LifeTimeMinutesInteger;

            var token = new JwtSecurityToken(
                issuer: _JwtBearerConfiguration.Issuer,
                audience: _JwtBearerConfiguration.Audience,
                expires: DateTime.Now.AddMinutes(minutesLifeTime),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
