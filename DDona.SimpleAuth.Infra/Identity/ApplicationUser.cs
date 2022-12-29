using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Infra.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public bool Inactive { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
