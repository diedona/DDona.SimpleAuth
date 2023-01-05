using DDona.SimpleAuth.Application.Identity.Entities;
using DDona.SimpleAuth.Application.Identity.Interfaces;
using DDona.SimpleAuth.Infra.Application.Base;
using DDona.SimpleAuth.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace DDona.SimpleAuth.Infra.Application.Identity.Repositories
{
    public class RefreshTokenRepository : BaseApplicationRepository<ApplicationUserRefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SimpleAuthDbContext context) : base(context)
        {
        }

        public async Task SaveToken(ApplicationUserRefreshToken refreshToken)
        {
            await _DbSet.AddAsync(refreshToken);
            await _Context.SaveChangesAsync();
        }

        public async Task<ApplicationUserRefreshToken?> FindRefreshToken(string userId, string refreshToken)
        {
            return await _DbSet.FirstOrDefaultAsync(x => x.AspNetUserId.Equals(userId) && x.Token.Equals(refreshToken));
        }

        public async Task DeleteToken(ApplicationUserRefreshToken refreshTokenEntity)
        {
            _DbSet.Remove(refreshTokenEntity);
            await _Context.SaveChangesAsync();
        }
    }
}
