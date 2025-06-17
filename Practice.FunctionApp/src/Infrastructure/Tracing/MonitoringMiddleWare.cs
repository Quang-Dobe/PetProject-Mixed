using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;

internal class MonitoringMiddleWare(IOptions<FunctionTracingOptions> options) : IFunctionsWorkerMiddleware
{
    public const string FunctionTraceKey = "_FUNCTION_TRACED_";

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
		if (options.Value.Enable)
		{
			var traceContext = CollectTraceContext(context, options.Value);
			var logger = context.GetLogger<MonitoringMiddleWare>();
			using (logger.BeginScope(traceContext))
			{
				context.Items[FunctionTraceKey] = traceContext;
				await next(context);
			}
		}
		else
		{
			await next(context);
		}
	}

    protected bool CanHandle(FunctionContext context)
    {
        return options.Value.Enable;
    }

    internal static IDictionary<string, object> CollectTraceContext(FunctionContext context, FunctionTracingOptions tracingOptions)
    {
        var customFunctionContextProvider = context.InstanceServices.GetService<IFunctionTraceContextProvider>();
        var traceContext = customFunctionContextProvider?.GetTraceContext(context);
        traceContext ??= new Dictionary<string, object>();

        if (!string.IsNullOrEmpty(tracingOptions.ContextKeys))
        {
            var contextKeys = tracingOptions.ContextKeys.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            foreach (var key in contextKeys)
            {
                if (context.BindingContext.BindingData.TryGetValue(key, out object contextValue) && contextValue != null)
                {
                    //Inogre if existed
                    traceContext.TryAdd(tracingOptions.PropNamePrefix + key, contextValue);
                }
            }
        }
        return traceContext;
    }
}