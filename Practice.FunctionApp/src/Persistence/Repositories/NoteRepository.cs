using FunctionApp.IsolatedDemo.Api.Domain.Entities;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal class NoteRepository : INoteRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    private bool _disposed = false;

    public NoteRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Note> CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        var connection = _connectionFactory.CreateConnectionAsync(cancellationToken);

        var result = await connection.CreateItemAsync(new Note() { Body = "Testing", Title = "Testing" });

        if (result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return note;
        }

        throw new ApplicationException("Could not save entity in db.");
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _connectionFactory?.Dispose();
        }

        _disposed = true;
    }

    ~NoteRepository()
    {
        Dispose(disposing: false);
    }
}
