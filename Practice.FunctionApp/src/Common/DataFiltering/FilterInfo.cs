using FunctionApp.IsolatedDemo.Api.Common.DataFiltering.Enums;

namespace FunctionApp.IsolatedDemo.Api.Common.DataFiltering;

public class FilterInfo
{
    public string Field { get; set; }

    public FilterOperator Operator { get; set; }

    public string Value { get; set; }
}
