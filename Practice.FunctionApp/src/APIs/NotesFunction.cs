using FunctionApp.IsolatedDemo.Api.DTOs.Responses;
using FunctionApp.IsolatedDemo.Api.DTOs.Requests;
using FunctionApp.IsolatedDemo.Api.Services;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

namespace FunctionApp.IsolatedDemo.Api.APIs;

internal class NotesFunction
{
    private readonly INoteService _noteService;
    private readonly ILogger<NotesFunction> _logger;

    public NotesFunction(INoteService noteService, ILogger<NotesFunction> logger)
    {
        _noteService = noteService;
        _logger = logger;
    }

    [Function("NotesFunction")]
	[OpenApiOperation(operationId: "NoteCreate", tags: [ "Note" ])]
	public async Task<CreateNoteResponse> Post(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "notes")][FromBody] CreateNoteRequest createNoteRequest, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("C# HTTP trigger NotesFunction processed a request.");

        try
        {
            var dto = await _noteService.CreateNoteAsync(createNoteRequest, cancellationToken);

            return new CreateNoteResponse()
            {
                Id = dto.Id,
                Title = dto.Title,
                Body = dto.Body,
                LastUpdatedOn = dto.LastUpdatedOn
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception in {ClassName} -> {MethodName} method.", nameof(NotesFunction), nameof(Post));

            return default;
        }
    }
}
