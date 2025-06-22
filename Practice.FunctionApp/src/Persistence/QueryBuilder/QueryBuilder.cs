using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Common.DataFiltering.Enums;
using FunctionApp.IsolatedDemo.Api.Common.Extensions;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using System.Linq.Expressions;

namespace FunctionApp.IsolatedDemo.Api.Persistence.QueryBuilder;

internal class QueryBuilder<TEntity> : IQueryBuilder<TEntity>
	where TEntity : BaseEntity
{
	private IQueryable<TEntity> _query;

	public QueryBuilder(IQueryable<TEntity> query)
	{
		_query = query;
	}

	public IQueryBuilder<TEntity> WithKeywords(KeywordsInfo keywordsInfo)
	{
		if (string.IsNullOrWhiteSpace(keywordsInfo.Keyword) || keywordsInfo.Fields.Count == 0)
		{
			return this;
		}

		Expression<Func<TEntity, bool>> expression = null;
		_query = _query.Where(expression.Build<TEntity>(keywordsInfo, QueryOperator.Or));

		return this;
	}

	public IQueryBuilder<TEntity> WithFilters(List<FilterInfo> filters)
	{
		if (filters == null) return this;

		Expression<Func<TEntity, bool>> expression = null;
		_query = _query.Where(expression.Build(filters, QueryOperator.And));

		return this;
	}

	public IQueryBuilder<TEntity> WithPagination(PaginationInfo pageInfo)
	{
		if (pageInfo != null)
		{
			var skip = (pageInfo.PageNumber - 1) * pageInfo.PageSize;
			_query = _query.Skip(skip).Take(pageInfo.PageSize);
		}
		return this;
	}

	public IQueryable<TEntity> Build() => _query;
}
