namespace FunctionApp.IsolatedDemo.Api.Domain.Entities;

internal abstract class BaseEntity
{
    public Guid Id { get; } = Guid.NewGuid();
}
