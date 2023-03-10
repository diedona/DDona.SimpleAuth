using DDona.SimpleAuth.Application.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Infra.Application.Identity.Managers
{
    /// <summary>
    /// An adapter for RoleManager<T> from ASP NET CORE Identity
    /// </summary>
    public class ApplicationRoleManager : IRoleManager
    {
        private readonly RoleManager<IdentityRole> _RoleManager;

        public ApplicationRoleManager(RoleManager<IdentityRole> roleManager)
        {
            _RoleManager = roleManager;
        }

        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _RoleManager.RoleExistsAsync(roleName);
        }
    }
}
