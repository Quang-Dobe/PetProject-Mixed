using FunctionApp.IsolatedDemo.Api.Application.Services;
using FunctionApp.IsolatedDemo.Api.Application.DTOs.Requests;
using FunctionApp.IsolatedDemo.Api.Application.DTOs.Responses;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net.Mime;
using System.Text.Json;
using System.Web.Http;
using System.Net;

namespace FunctionApp.IsolatedDemo.Api.Application.APIs;

internal class NotesFunction
{
    private readonly INoteService _noteService;
    private readonly ILogger<NotesFunction> _logger;

    public NotesFunction(INoteService noteService, ILogger<NotesFunction> logger)
    {
        _noteService = noteService;
        _logger = logger;
    }

    [Function("CreateNoteFunction")]
    [OpenApiOperation(operationId: "CreateNote", tags: ["Note"])]
    [OpenApiRequestBody(contentType: MediaTypeNames.Application.Json, bodyType: typeof(CreateNoteRequest), Required = true, Description = "Note Create")]
    [OpenApiResponseWithBody(System.Net.HttpStatusCode.Created, nameof(CreateNoteResponse), typeof(CreateNoteResponse))]
    public async Task<HttpResponseData> Create([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/note")]
        HttpRequestData request, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("C# HTTP trigger NotesFunction processed a request.");

        try
        {
			var createNoteRequest = await JsonSerializer.DeserializeAsync<CreateNoteRequest>(
				request.Body,
		        new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
		        cancellationToken);

			var dto = await _noteService.CreateNoteAsync(createNoteRequest, cancellationToken);

            var response = request.CreateResponse(HttpStatusCode.Created);
			await response.WriteAsJsonAsync(new CreateNoteResponse()
			{
				Id = dto.Id,
				Title = dto.Title,
				Body = dto.Body,
				LastUpdatedOn = dto.LastUpdatedOn
			}, cancellationToken);

			return response;

		}
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception in {ClassName} -> {MethodName} method.", nameof(NotesFunction), "POST");

            return default;
        }
    }

	[Function("UpdateNoteFunction")]
	[OpenApiOperation(operationId: "UpdateNote", tags: ["Note"])]
    [OpenApiParameter("id", Type = typeof(string))]
	[OpenApiRequestBody(contentType: MediaTypeNames.Application.Json, bodyType: typeof(UpdateNoteRequest), Required = true, Description = "Note Create")]
    [OpenApiResponseWithBody(System.Net.HttpStatusCode.OK, nameof(UpdateNoteRequest), typeof(UpdateNoteRequest))]
	public async Task<HttpResponseData> Update([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/note/{id}")]
        HttpRequestData request,
        [FromUri] string id,
        CancellationToken cancellationToken = default)
	{
		_logger.LogInformation("C# HTTP trigger NotesFunction processed a request.");

		try
		{
			var updateNoteRequest = await JsonSerializer.DeserializeAsync<UpdateNoteRequest>(
				request.Body,
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true },
				cancellationToken);

			var dto = await _noteService.UpdateNoteAsync(updateNoteRequest, id, cancellationToken);

			var response = request.CreateResponse(HttpStatusCode.OK);
			await response.WriteAsJsonAsync(new UpdateNoteResponse()
			{
				Title = dto.Title,
				Body = dto.Body,
				LastUpdatedOn = dto.LastUpdatedOn
			}, cancellationToken);

			return response;
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "Exception in {ClassName} -> {MethodName} method.", nameof(NotesFunction), "POST");

			return default;
		}
	}
}
