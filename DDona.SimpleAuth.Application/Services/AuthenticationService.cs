using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Application.Models.AppSettings;
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
        private readonly JwtBearerConfiguration _JwtBearerConfiguration;

        public AuthenticationService(IUserManager userManager, IOptions<JwtBearerConfiguration> jwtBearerConfiguration)
        {
            _UserManager = userManager;
            _JwtBearerConfiguration = jwtBearerConfiguration.Value;
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(email);
            if (requestedUser is null)
                return false;

            if (!await _UserManager.CheckPasswordAsync(requestedUser, password))
                return false;

            if (!requestedUser.EmailConfirmed || requestedUser.Inactive)
                return false;

            return true;
        }

        private async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(email);
            return await _UserManager.GetRolesAsync(requestedUser);
        }

        public async Task<JwtSecurityToken> GenerateToken(string email)
        {
            var roles = await GetUserRolesAsync(email);
            var claims = new List<Claim>() { new Claim(ClaimTypes.Sid, email) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

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

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _UserManager.CreateAsync(user, password);
        }
    }
}
