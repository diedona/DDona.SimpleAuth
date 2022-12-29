using DDona.SimpleAuth.Domain.Entities.ApplicationUser;
using Microsoft.AspNetCore.Identity;

namespace DDona.SimpleAuth.Infra.Identity
{
    public class ApplicationUser : IdentityUser, IDomainApplicationUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
