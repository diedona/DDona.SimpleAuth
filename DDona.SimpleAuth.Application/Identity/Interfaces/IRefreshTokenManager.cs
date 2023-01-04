namespace DDona.SimpleAuth.Application.Identity.Interfaces
{
    public interface IRefreshTokenManager
    {
        Task AddTokenToUser(string userId, string refreshToken, DateTime validTo);
    }
}
