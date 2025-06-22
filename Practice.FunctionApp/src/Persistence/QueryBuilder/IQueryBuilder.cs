using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;

namespace FunctionApp.IsolatedDemo.Api.Persistence.QueryBuilder;

internal interface IQueryBuilder<TEntity>
{
	IQueryBuilder<TEntity> WithKeywords(KeywordsInfo keywordsInfo);

	IQueryBuilder<TEntity> WithFilters(List<FilterInfo> filters);

	IQueryBuilder<TEntity> WithPagination(PaginationInfo pageInfo);

	IQueryable<TEntity> Build();
}
