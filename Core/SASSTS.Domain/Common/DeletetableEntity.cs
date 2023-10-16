namespace SASSTS.Domain.Common
{
    public abstract class DeletetableEntity : AuditableEntity
    {
        public bool? IsDeleted { get; set; }
    }
}
