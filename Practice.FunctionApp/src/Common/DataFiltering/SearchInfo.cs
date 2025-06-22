using FunctionApp.IsolatedDemo.Api.Domain.Entities;

namespace FunctionApp.IsolatedDemo.Api.Common.DataFiltering;

public class SearchInfo<TEntity>
    where TEntity : BaseEntity
{
    public KeywordsInfo KeywordsInfo { get; set; } = default;

    public List<FilterInfo> FilterInfo { get; set; } = default;

    public PaginationInfo PaginationInfo { get; set; } = default;
}
