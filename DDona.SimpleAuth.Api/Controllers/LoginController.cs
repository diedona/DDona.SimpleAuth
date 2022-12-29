using DDona.SimpleAuth.Domain.DTO.User;
using DDona.SimpleAuth.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public LoginController(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO request)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(request.Email);
            if (requestedUser is null)
                return BadRequest("Failed to authenticate");

            if (await _UserManager.CheckPasswordAsync(requestedUser, request.Password))
                return Ok(await _UserManager.GetRolesAsync(requestedUser));

            return BadRequest("Failed to authenticate");
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            var user = new ApplicationUser
            {
                UserName = createUserDTO.Email,
                Email = createUserDTO.Email,
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName
            };

            var result = await _UserManager.CreateAsync(user, createUserDTO.Password);
            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
