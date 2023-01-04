namespace DDona.SimpleAuth.Application.Identity.Interfaces
{
    public interface IRoleManager
    {
        Task<bool> RoleExistsAsync(string roleName);
    }
}
