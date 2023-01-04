using DDona.SimpleAuth.Application.Identity.Entities;
using DDona.SimpleAuth.Application.Models.Jwt;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DDona.SimpleAuth.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<JwtTokenResponse> GenerateToken(string email);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string accessToken);
    }
}