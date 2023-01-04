using DDona.SimpleAuth.Domain.DTO.User;
using Microsoft.AspNetCore.Mvc;
using DDona.SimpleAuth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DDona.SimpleAuth.Domain.Constants;
using DDona.SimpleAuth.Api.Extensions;
using DDona.SimpleAuth.Application.Identity.Entities;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _AuthenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _AuthenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO request)
        {
            if (!await _AuthenticationService.AuthenticateUser(request.Email, request.Password))
                return BadRequest("Failed to authenticate");

            var token = await _AuthenticationService.GenerateToken(request.Email);
            return Ok(token);
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
            string username = User.GetUsername();
            string role = User.GetRole();
            return Ok($"Hm... {username} - either you are administrator or worker. But i think you are '{role}', right?");
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

            var result = await _AuthenticationService.CreateAsync(user, createUserDTO.Password, createUserDTO.RoleName);
            if (result.Succeeded)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
