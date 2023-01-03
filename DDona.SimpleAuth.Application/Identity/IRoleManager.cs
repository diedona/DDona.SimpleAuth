namespace DDona.SimpleAuth.Application.Identity
{
    public interface IRoleManager
    {
        Task<bool> RoleExistsAsync(string roleName);
    }
}
