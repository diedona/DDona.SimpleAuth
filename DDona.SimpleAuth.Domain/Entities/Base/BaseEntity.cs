namespace DDona.SimpleAuth.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set;}

        protected BaseEntity() { }
    }
}
