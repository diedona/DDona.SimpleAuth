using DDona.SimpleAuth.Application.Identity.Entities;

namespace DDona.SimpleAuth.Application.Identity.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SaveToken(ApplicationUserRefreshToken refreshToken);
        Task<ApplicationUserRefreshToken?> FindRefreshToken(string userId, string refreshToken);
        Task DeleteToken(ApplicationUserRefreshToken refreshTokenEntity);
    }
}
