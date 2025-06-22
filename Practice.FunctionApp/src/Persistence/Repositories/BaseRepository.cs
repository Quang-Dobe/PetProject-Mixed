using FunctionApp.IsolatedDemo.Api.Common;
using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
	where TEntity : BaseEntity
{
	protected readonly ICosmosDbConnectionFactory _connectionFactory;
	protected readonly Container _container;
	protected bool _disposed = false;

	public BaseRepository(ICosmosDbConnectionFactory connectionFactory)
	{
		_connectionFactory = connectionFactory;
		_container = connectionFactory.CreateConnectionAsync();
	}

	public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		var result = await _container.CreateItemAsync(entity, cancellationToken: cancellationToken);

		if (result.StatusCode == System.Net.HttpStatusCode.Created)
		{
			return result;
		}

		throw new ApplicationException("Could not save entity in db.");
	}

	public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		var result = await _container.UpsertItemAsync(entity, cancellationToken: cancellationToken);

		if (result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			return result;
		}

		throw new ApplicationException("Could not save entity in db.");
	}

	public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		await DeleteByIdAsync(entity.Id.ToString(), cancellationToken: cancellationToken);
	}

	public async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		var result = await _container.DeleteItemAsync<TEntity>(
			id,
			PartitionKey.None, 
			cancellationToken: cancellationToken);

		if (result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			return;
		}

		throw new ApplicationException("Could not save entity in db.");
	}

	public async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default)
	{
		var result = await _container.ReadItemAsync<TEntity>(
			id,
			PartitionKey.None, 
			cancellationToken: cancellationToken);

		if (result.StatusCode == System.Net.HttpStatusCode.OK)
		{
			return result;
		}

		throw new ApplicationException("Could not save entity in db.");
	}

	public async Task<PaginationListInfo<TEntity>> SearchAsync(SearchInfo<TEntity> searchInfo, CancellationToken cancellationToken = default)
	{
		var query = _container.GetItemLinqQueryable<TEntity>();

		var queryDefinition = CosmosQueryBuilder<TEntity>.New(query)
			.WithKeywords(searchInfo.KeywordsInfo)
			.WithFilters(searchInfo.FilterInfo)
			.WithPagination(searchInfo.PaginationInfo)
			.Build()
			.ToQueryDefinition();

		var result = new PaginationListInfo<TEntity>();
		using (var iterator = _container.GetItemQueryIterator<TEntity>(queryDefinition))
		{
			while (iterator.HasMoreResults)
			{
				var response = await iterator.ReadNextAsync();
				result.Data.AddRange(response.Resource);
			}
		}

		return result;
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
}
