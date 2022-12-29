namespace DDona.SimpleAuth.Domain.Entities.ApplicationUser
{
    public interface IDomainApplicationUser
    {
        string UserName { get; }
        string FirstName { get; }
        string LastName { get; }
        bool Inactive { get; set; }
        bool LockoutEnabled { get; set; }
    }
}
