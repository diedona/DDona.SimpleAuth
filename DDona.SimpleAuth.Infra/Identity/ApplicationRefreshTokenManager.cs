using DDona.SimpleAuth.Application.Identity.Entities;
using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Infra.Context;

namespace DDona.SimpleAuth.Infra.Identity
{
    public class ApplicationRefreshTokenManager : IRefreshTokenManager
    {
        private readonly SimpleAuthDbContext _Context;

        public ApplicationRefreshTokenManager(SimpleAuthDbContext context)
        {
            _Context = context;
        }

        public async Task AddTokenToUser(string userId, string refreshToken, DateTime validTo)
        {
            var refreshTokenDB = _Context.Set<ApplicationUserRefreshToken>();
            var newRefreshToken = new ApplicationUserRefreshToken(userId, refreshToken, validTo);
            await refreshTokenDB.AddAsync(newRefreshToken);
            await _Context.SaveChangesAsync();
        }
    }
}
