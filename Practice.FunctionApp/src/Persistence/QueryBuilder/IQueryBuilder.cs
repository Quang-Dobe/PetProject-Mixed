using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using System.Linq.Expressions;

namespace FunctionApp.IsolatedDemo.Api.Persistence.QueryBuilder;

internal interface IQueryBuilder<TEntity>
	where TEntity : BaseEntity
{
	IQueryBuilder<TEntity> WithKeywords(KeywordsInfo keywordsInfo);

	IQueryBuilder<TEntity> WithFilters(List<FilterInfo> filters);

	IQueryBuilder<TEntity> WithPagination(PaginationInfo pageInfo);

	IQueryable<TEntity> Build();
}
