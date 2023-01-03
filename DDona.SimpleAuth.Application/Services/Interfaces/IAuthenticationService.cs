using DDona.SimpleAuth.Application.Identity;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace DDona.SimpleAuth.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<JwtSecurityToken> GenerateToken(string email);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
    }
}