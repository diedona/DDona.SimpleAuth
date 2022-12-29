using DDona.SimpleAuth.Application.Identity;

namespace DDona.SimpleAuth.Application.Services
{
    public class AuthenticationService
    {
        private readonly IUserManager _UserManager;

        public AuthenticationService(IUserManager userManager)
        {
            _UserManager = userManager;
        }


    }
}
