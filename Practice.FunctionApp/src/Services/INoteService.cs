using FunctionApp.IsolatedDemo.Api.Domain.Dtos;
using FunctionApp.IsolatedDemo.Api.DTOs.Requests;

namespace FunctionApp.IsolatedDemo.Api.Services;

internal interface INoteService
{
    Task<NoteDto> CreateNoteAsync(CreateNoteRequest request, CancellationToken ct = default);
}
