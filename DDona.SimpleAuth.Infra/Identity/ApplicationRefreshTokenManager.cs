using DDona.SimpleAuth.Application.Identity.Entities;
using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Identity
{
    public class ApplicationRefreshTokenManager : IRefreshTokenManager
    {
        private readonly SimpleAuthDbContext _Context;
        private readonly DbSet<ApplicationUserRefreshToken> _Set;

        public ApplicationRefreshTokenManager(SimpleAuthDbContext context)
        {
            _Context = context;
            _Set = _Context.Set<ApplicationUserRefreshToken>();
        }

        public async Task SaveToken(ApplicationUserRefreshToken refreshToken)
        {
            await _Set.AddAsync(refreshToken);
            await _Context.SaveChangesAsync();
        }

        public async Task<ApplicationUserRefreshToken?> FindRefreshToken(string userId, string refreshToken)
        {
            return await _Set.FirstOrDefaultAsync(x => x.AspNetUserId.Equals(userId) && x.Token.Equals(refreshToken));
        }
    }
}
