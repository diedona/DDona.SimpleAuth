using DDona.SimpleAuth.Application.Identity;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateUser(string email, string password);
        Task<IList<string>> GetUserRolesAsync(string email);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    }
}