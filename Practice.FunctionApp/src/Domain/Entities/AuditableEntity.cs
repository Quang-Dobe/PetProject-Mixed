namespace FunctionApp.IsolatedDemo.Api.Domain.Entities;

internal abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdatedOn { get; set; }
}
