using DDona.SimpleAuth.Application.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Application.Identity.Interfaces
{
    public interface IUserManager
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);
    }
}
