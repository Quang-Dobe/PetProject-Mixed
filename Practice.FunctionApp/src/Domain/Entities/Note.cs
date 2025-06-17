namespace FunctionApp.IsolatedDemo.Api.Domain.Entities;

internal class Note : AuditableEntity
{
    public string Title { get; set; } = default!;

    public string Body { get; set; } = default!;
}
