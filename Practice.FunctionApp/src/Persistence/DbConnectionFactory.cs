using Microsoft.Azure.Cosmos;

namespace FunctionApp.IsolatedDemo.Api.Persistence;

internal class DbConnectionFactory : IDbConnectionFactory
{
    private readonly Container _container;

    public DbConnectionFactory(CosmosClient client, string databaseName, string containerName)
    {
        _container = client.GetContainer(databaseName, containerName);
    }

    public Container CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        return _container;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
