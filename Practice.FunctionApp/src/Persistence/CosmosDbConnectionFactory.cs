using FunctionApp.IsolatedDemo.Api.Persistence.DbFactory;
using Microsoft.Azure.Cosmos;

namespace FunctionApp.IsolatedDemo.Api.Persistence;

internal class CosmosDbConnectionFactory : DbConnectionFactory<Container>, ICosmosDbConnectionFactory
{
	private readonly Container _container;

	public CosmosDbConnectionFactory(CosmosClient client, string databaseName, string containerName)
	{
		_container = client.GetContainer(databaseName, containerName);
	}

	public override Container CreateConnectionAsync(CancellationToken cancellationToken = default)
	{
		return _container;
	}

	public override void Dispose()
	{
		GC.SuppressFinalize(this);
	}
}
