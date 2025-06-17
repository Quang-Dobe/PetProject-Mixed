namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;

internal interface IFunctionTraceContextProvider
{
    IDictionary<string, object> GetTraceContext(FunctionContext context);
}
