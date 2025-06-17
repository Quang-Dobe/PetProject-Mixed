using FunctionApp.IsolatedDemo.Api.Domain.Entities;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal interface INoteRepository : IBaseRepository
{
    Task<Note> CreateAsync(Note note, CancellationToken ct = default);
}
