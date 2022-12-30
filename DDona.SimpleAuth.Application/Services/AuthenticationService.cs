using DDona.SimpleAuth.Application.Identity;
using DDona.SimpleAuth.Application.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserManager _UserManager;

        public AuthenticationService(IUserManager userManager)
        {
            _UserManager = userManager;
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

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var requestedUser = await _UserManager.FindByEmailAsync(email);
            return await _UserManager.GetRolesAsync(requestedUser);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            return await _UserManager.CreateAsync(user, password);
        }
    }
}
