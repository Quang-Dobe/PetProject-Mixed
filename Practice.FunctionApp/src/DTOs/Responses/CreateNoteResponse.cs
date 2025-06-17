namespace FunctionApp.IsolatedDemo.Api.DTOs.Responses;

internal class CreateNoteResponse
{
    public string Id { get; set; } = default!;

    public string Title { get; set; } = default!;

    public string Body { get; set; } = default!;

    public DateTime LastUpdatedOn { get; set; }
}
