using DDona.SimpleAuth.Api.Models.AppSettings;
using DDona.SimpleAuth.Domain.DTO.User;
using DDona.SimpleAuth.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly JwtBearerConfiguration _JwtBearerConfiguration;

        public LoginController(UserManager<ApplicationUser> userManager, IOptions<JwtBearerConfiguration> jwtBearerConfigurationOptions)
        {
            _UserManager = userManager;
            _JwtBearerConfiguration = jwtBearerConfigurationOptions.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO request)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(request.Email);
            if (requestedUser is null)
                return BadRequest("Failed to authenticate");

            if (!await _UserManager.CheckPasswordAsync(requestedUser, request.Password))
            {
                await _UserManager.AccessFailedAsync(requestedUser);
                return BadRequest("Failed to authenticate");
            }

            if(!requestedUser.EmailConfirmed || requestedUser.Inactive)
            {
                await _UserManager.AccessFailedAsync(requestedUser);
                return BadRequest("Failed to authenticate");
            }

            await _UserManager.ResetAccessFailedCountAsync(requestedUser);
            return Ok(await _UserManager.GetRolesAsync(requestedUser));            
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

            var result = await _UserManager.CreateAsync(user, createUserDTO.Password);
            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
