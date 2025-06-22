using FunctionApp.IsolatedDemo.Api.Domain.Entities;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal class NoteRepository : BaseRepository<Note>, INoteRepository
{
    public NoteRepository(ICosmosDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}
