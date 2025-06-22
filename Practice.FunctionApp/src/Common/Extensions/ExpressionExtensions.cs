using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Common.DataFiltering.Enums;
using System.Linq.Expressions;

namespace FunctionApp.IsolatedDemo.Api.Common.Extensions;

public static class ExpressionExtensions
{
	public static Expression<Func<TEntity, bool>> Build<TEntity>(this Expression<Func<TEntity, bool>> expression, KeywordsInfo keywordsInfo, QueryOperator @operator = QueryOperator.And)
	{
		if (keywordsInfo == null || keywordsInfo.Fields.Count() == 0)
			return expression;

		var param = Expression.Parameter(typeof(TEntity), "x");
		Expression combineExpression = null;

		foreach (var field in keywordsInfo.Fields)
		{
			var member = Expression.PropertyOrField(param, field);
			var constant = Expression.Constant(Convert.ChangeType(keywordsInfo.Keyword, member.Type));
			var filterExpression = GetFilterExpression(member, constant, FilterOperator.Contains);

			combineExpression = GetCombinedExpression(combineExpression, filterExpression, @operator);
		}

		return Expression.Lambda<Func<TEntity, bool>>(combineExpression, param);
	}

	public static Expression<Func<TEntity, bool>> Build<TEntity>(this Expression<Func<TEntity, bool>> expression, IEnumerable<FilterInfo> filterInfo, QueryOperator @operator = QueryOperator.And)
	{
		if (filterInfo == null || filterInfo.Count() == 0)
			return expression;

		var param = Expression.Parameter(typeof(TEntity), "x");
		Expression combineExpression = null;

		foreach (var filter in filterInfo)
		{
			var member = Expression.PropertyOrField(param, filter.Field);
			var constant = Expression.Constant(Convert.ChangeType(filter.Value, member.Type));
			var filterExpression = GetFilterExpression(member, constant, filter.Operator);

			combineExpression = GetCombinedExpression(combineExpression, filterExpression, @operator);
		}

		return Expression.Lambda<Func<TEntity, bool>>(combineExpression, param);
	}

	private static Expression GetFilterExpression(MemberExpression member, ConstantExpression constant, FilterOperator @operator)
	{
		return @operator switch
		{
			FilterOperator.Equal => Expression.Equal(member, constant),
			FilterOperator.LessThan => Expression.LessThan(member, constant),
			FilterOperator.GreaterThan => Expression.GreaterThan(member, constant),
			FilterOperator.LessThanOrEqual => Expression.LessThanOrEqual(member, constant),
			FilterOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(member, constant),
			FilterOperator.Contains => Expression.Call(member, nameof(string.Contains), null, constant),
			_ => throw new NotSupportedException($"Unsupported operator: {@operator}")
		};
	}

	private static Expression GetCombinedExpression(Expression expression, Expression filterExpression, QueryOperator @operator, bool? condition = true)
	{
		if (expression == null)
		{
			return filterExpression;
		}

		switch (@operator)
		{
			case QueryOperator.And:
				return Expression.And(expression, filterExpression);
			case QueryOperator.Or:
				return Expression.Or(expression, filterExpression);
			case QueryOperator.AndIf:
				return condition == true ? Expression.And(expression, filterExpression) : expression;
			case QueryOperator.OrIf:
				return condition == true ? Expression.Or(expression, filterExpression) : expression;
		}

		return expression;
	}
}