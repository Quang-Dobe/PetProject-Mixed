using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using FunctionApp.IsolatedDemo.Api.Persistence.QueryBuilder;

namespace FunctionApp.IsolatedDemo.Api.Persistence;

internal class CosmosQueryBuilder<TEntity> : QueryBuilder<TEntity>
    where TEntity : BaseEntity
{
    public CosmosQueryBuilder(IQueryable<TEntity> query) : base(query)
    {
    }

	public static IQueryBuilder<TEntity> New(IQueryable<TEntity> query) => new CosmosQueryBuilder<TEntity>(query);
}
