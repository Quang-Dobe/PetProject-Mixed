using Microsoft.Extensions.Configuration;

namespace FunctionApp.IsolatedDemo.Api.Persistence.DbFactory;

internal class DbConnectionFactory<TContainer> : IDbConnectionFactory<TContainer>
{
    private readonly TContainer _container;

    public DbConnectionFactory()
    {
    }

    public virtual TContainer CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        return _container;
    }

	public virtual TContainer CreateConnectionAsync(IConfiguration configuration, CancellationToken cancellationToken = default)
	{
		return _container;
	}

	public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
