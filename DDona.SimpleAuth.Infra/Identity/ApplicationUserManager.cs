using DDona.SimpleAuth.Application.Identity;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Infra.Identity
{
    /// <summary>
    /// An adapter for the UserManager<T> from ASP NET CORE Identity
    /// </summary>
    public class ApplicationUserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public ApplicationUserManager(UserManager<ApplicationUser> userManager)
        {
            _UserManager = userManager;
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _UserManager.CheckPasswordAsync(user, password);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _UserManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _UserManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _UserManager.GetRolesAsync(user);
        }
    }
}
