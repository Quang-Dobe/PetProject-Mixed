using FunctionApp.IsolatedDemo.Api.Application.DTOs.Requests;
using FunctionApp.IsolatedDemo.Api.Domain.Dtos;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using FunctionApp.IsolatedDemo.Api.Infrastructure.Provider;
using FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

namespace FunctionApp.IsolatedDemo.Api.Application.Services;

internal class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ILogger<NoteService> _logger;

    public NoteService(
        INoteRepository noteRepository,
        IDateTimeProvider dateTimeProvider,
        ILogger<NoteService> logger)
    {
        _noteRepository = noteRepository;
        _dateTimeProvider = dateTimeProvider;
        _logger = logger;
    }

    public async Task<NoteDto> CreateNoteAsync(CreateNoteRequest request, CancellationToken ct = default)
    {
        if (string.IsNullOrEmpty(request.Title) || string.IsNullOrEmpty(request.Body))
        {
            _logger.LogError("Title or body of note cannot be empty. Returning null by default.");

            return null;
        }

        var newNote = await _noteRepository.CreateAsync(new Note
        {
            Title = request.Title,
            Body = request.Body,
            CreatedAt = _dateTimeProvider.UtcNow,
            LastUpdatedOn = _dateTimeProvider.UtcNow
        }, ct);

        return new NoteDto
        {
            Id = newNote.Id.ToString(),
            Title = newNote.Title,
            LastUpdatedOn = newNote.LastUpdatedOn,
            Body = newNote.Body
        };
    }
}
