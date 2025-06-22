using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using FunctionApp.IsolatedDemo.Api.Persistence.DbFactory;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal class NoteRepository : BaseRepository<Note>, INoteRepository
{
    public NoteRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}
