using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Application.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool Inactive { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<ApplicationUserRefreshToken> RefreshTokens { get; set; } = new List<ApplicationUserRefreshToken>();
    }
}
