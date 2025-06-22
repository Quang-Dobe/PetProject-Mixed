using FunctionApp.IsolatedDemo.Api.Application.DTOs.Requests;
using FunctionApp.IsolatedDemo.Api.Domain.Dtos;

namespace FunctionApp.IsolatedDemo.Api.Application.Services;

internal interface INoteService
{
    Task<NoteDto> CreateNoteAsync(CreateNoteRequest request, CancellationToken cancellationToken = default);

    Task<NoteDto> UpdateNoteAsync(UpdateNoteRequest request, string noteId, CancellationToken cancellationToken = default);
}
