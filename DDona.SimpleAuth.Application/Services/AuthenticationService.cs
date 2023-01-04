using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Application.Models.AppSettings;
using DDona.SimpleAuth.Application.Models.Jwt;
using DDona.SimpleAuth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DDona.SimpleAuth.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManager _UserManager;
        private readonly IRoleManager _RoleManager;
        private readonly JwtBearerConfiguration _JwtBearerConfiguration;

        public AuthenticationService(IUserManager userManager, IOptions<JwtBearerConfiguration> jwtBearerConfiguration, IRoleManager roleManager)
        {
            _UserManager = userManager;
            _JwtBearerConfiguration = jwtBearerConfiguration.Value;
            _RoleManager = roleManager;
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(email);
            if (requestedUser is null)
                return false;

            if (!await _UserManager.CheckPasswordAsync(requestedUser, password))
                return false;

            if (requestedUser.Inactive)
                return false;

            return true;
        }

        private async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(email);
            return await _UserManager.GetRolesAsync(requestedUser);
        }

        public async Task<JwtTokenResponse> GenerateToken(string email)
        {
            var roles = await GetUserRolesAsync(email);
            var claims = new List<Claim>() { new Claim(ClaimTypes.Sid, email) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtBearerConfiguration.Key));
            var minutesLifeTime = _JwtBearerConfiguration.AccessTokenLifeTimeMinutesInteger;
            var token = new JwtSecurityToken(
                issuer: _JwtBearerConfiguration.Issuer,
                audience: _JwtBearerConfiguration.Audience,
                expires: DateTime.Now.AddMinutes(minutesLifeTime),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtTokenResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                AccessTokenExpiration = token.ValidTo,
                RefreshToken = "nothing yet"
            };
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string roleName)
        {
            var userCreationStatus = await _UserManager.CreateAsync(user, password);
            bool errorWhileCreating = userCreationStatus.Errors.Any();
            if (errorWhileCreating)
                return userCreationStatus;

            var roleExists = await _RoleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _UserManager.DeleteAsync(user);
                return IdentityResult.Failed(new IdentityError() { Description = "Role does not exist" });
            }

            var addToRoleStatus = await _UserManager.AddToRoleAsync(user, roleName);
            bool errorWhileAddRole = addToRoleStatus.Errors.Any();
            if (errorWhileAddRole)
                await _UserManager.DeleteAsync(user);

            return addToRoleStatus;
        }
    }
}
