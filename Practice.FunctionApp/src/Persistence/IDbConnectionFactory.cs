using Microsoft.Azure.Cosmos;

namespace FunctionApp.IsolatedDemo.Api.Persistence;

internal interface IDbConnectionFactory : IDisposable
{
    public Container CreateConnectionAsync(CancellationToken cancellationToken = default);
}