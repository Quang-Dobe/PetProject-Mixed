using System.Text.Json.Serialization;

namespace FunctionApp.IsolatedDemo.Api.Application.DTOs.Requests;

internal class UpdateNoteRequest
{
	[JsonPropertyName("title")]
	public string Title { get; init; } = default!;

	[JsonPropertyName("body")]
	public string Body { get; init; } = default!;
}
