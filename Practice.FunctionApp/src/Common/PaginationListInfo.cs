using FunctionApp.IsolatedDemo.Api.Common.DataFiltering;
using FunctionApp.IsolatedDemo.Api.Domain.Entities;
using System.Linq.Expressions;

namespace FunctionApp.IsolatedDemo.Api.Common
{
    internal class PaginationListInfo<TEntity>
        where TEntity : BaseEntity
    {
        public List<TEntity> Data { get; set; } = default;

        public SearchInfo<TEntity> SearchInfo { get; set; } = default;
    }
}
