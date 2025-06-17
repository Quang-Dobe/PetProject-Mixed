using System.Text.Json.Serialization;

namespace FunctionApp.IsolatedDemo.Api.DTOs.Requests;

internal class CreateNoteRequest
{
    [JsonPropertyName("title")]
    public string Title { get; init; } = default!;

    [JsonPropertyName("body")]
    public string Body { get; init; } = default!;
}
