using DDona.SimpleAuth.Application.Extensions;
using DDona.SimpleAuth.Application.Identity.Entities;
using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Application.Models.AppSettings;
using DDona.SimpleAuth.Application.Models.Jwt;
using DDona.SimpleAuth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DDona.SimpleAuth.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManager _UserManager;
        private readonly IRoleManager _RoleManager;
        private readonly IRefreshTokenManager _RefreshTokenManager;
        private readonly JwtBearerConfiguration _JwtBearerConfiguration;

        public AuthenticationService(IUserManager userManager, IOptions<JwtBearerConfiguration> jwtBearerConfiguration, IRoleManager roleManager, IRefreshTokenManager refreshTokenManager)
        {
            _UserManager = userManager;
            _JwtBearerConfiguration = jwtBearerConfiguration.Value;
            _RoleManager = roleManager;
            _RefreshTokenManager = refreshTokenManager;
        }

        private SymmetricSecurityKey GetSymmetrictSecurityKey() => new(Encoding.UTF8.GetBytes(_JwtBearerConfiguration.Key));

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

        public async Task<JwtTokenResponse?> GenerateRefreshToken(ClaimsPrincipal? principal, string refreshToken)
        {
            if (principal is null)
                return null;

            var email = principal.GetUsername();
            if (string.IsNullOrEmpty(email))
                return null;

            var user = await _UserManager.FindByEmailAsync(email);
            var refreshTokenEntity = await _RefreshTokenManager.FindRefreshToken(user.Id, refreshToken);
            if (refreshTokenEntity is null)
                return null;

            if (!refreshTokenEntity.IsTokenValid())
            {
                await _RefreshTokenManager.DeleteToken(refreshTokenEntity);
                return null;
            }

            await _RefreshTokenManager.DeleteToken(refreshTokenEntity);
            return await GenerateToken(user.Email);
        }

        public async Task<JwtTokenResponse> GenerateToken(string email)
        {
            var roles = await GetUserRolesAsync(email);
            var claims = new List<Claim>() { new Claim(ClaimTypes.Sid, email) };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var minutesLifeTime = _JwtBearerConfiguration.AccessTokenLifeTimeMinutesInteger;
            var token = new JwtSecurityToken(
                issuer: _JwtBearerConfiguration.Issuer,
                audience: _JwtBearerConfiguration.Audience,
                expires: DateTime.UtcNow.AddMinutes(minutesLifeTime),
                claims: claims,
                signingCredentials: new SigningCredentials(GetSymmetrictSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            return new JwtTokenResponse()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                AccessTokenExpiration = token.ValidTo,
                RefreshToken = await GenerateRefreshToken(email)
            };
        }

        private async Task<string> GenerateRefreshToken(string email)
        {
            ApplicationUser user = await _UserManager.FindByEmailAsync(email);
            ApplicationUserRefreshToken newRefreshToken = GenerateRefreshTokenEntity(user.Id);
            await _RefreshTokenManager.SaveToken(newRefreshToken);
            return newRefreshToken.Token;
        }

        private ApplicationUserRefreshToken GenerateRefreshTokenEntity(string userId)
        {
            string refreshToken = GenerateRandomString();
            DateTime validTo = DateTime.UtcNow.AddMinutes(_JwtBearerConfiguration.RefreshTokenLifeTimeMinutesInteger);
            return new ApplicationUserRefreshToken(userId, refreshToken, validTo);
        }

        private string GenerateRandomString()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
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

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = _JwtBearerConfiguration.Audience,
                ValidateIssuer = true,
                ValidIssuer = _JwtBearerConfiguration.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSymmetrictSecurityKey(),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
