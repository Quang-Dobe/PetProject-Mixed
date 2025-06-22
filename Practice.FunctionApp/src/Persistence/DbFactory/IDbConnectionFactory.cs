using Microsoft.Extensions.Configuration;

namespace FunctionApp.IsolatedDemo.Api.Persistence.DbFactory;

internal interface IDbConnectionFactory<TContainer> : IDisposable
{
	TContainer CreateConnectionAsync(CancellationToken cancellationToken = default);

	TContainer CreateConnectionAsync(IConfiguration configuration, CancellationToken cancellationToken = default);
}