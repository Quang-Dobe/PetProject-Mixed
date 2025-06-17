using System.IdentityModel.Tokens.Jwt;

namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;

internal class FunctionTraceContextProvider : IFunctionTraceContextProvider
{
    public IDictionary<string, object> GetTraceContext(FunctionContext context)
    {
		var traceContext = new Dictionary<string, object>();

		var userId = GetUserId(context);
        var requestId = context.InvocationId;
		
		var requestData = context.GetHttpRequestDataAsync().Result;
		if (requestData != null)
		{
			if (requestData.Headers.TryGetValues(AppConstants.HttpHeader.XCorrelationId, out var values))
			{
				requestId = values.First();
			}
		}

		traceContext["UserId"] = userId;
		traceContext["RequestId"] = requestId;

		if (!string.IsNullOrEmpty(requestId))
		{
			try
			{
				context.GetHttpResponseData()?.Headers.Add(AppConstants.HttpHeader.XCorrelationId, requestId);
			}
			catch (Exception ex)
			{
				var logger = context.GetLogger<MonitoringMiddleWare>();
				logger.LogDebug($"Error: {requestId} - {ex.Message}");
			}
		}

		return traceContext;
    }

    private string GetUserId(FunctionContext context)
    {
        if (context.BindingContext.BindingData.TryGetValue("req", out var reqObj) && reqObj is HttpRequestData request &&
            request.Headers.TryGetValues("Authorization", out var authHeaders))
        {
            var bearerToken = authHeaders.FirstOrDefault()?.Split(' ').Last();
            var handler = new JwtSecurityTokenHandler();

            if (!string.IsNullOrEmpty(bearerToken) && handler.CanReadToken(bearerToken))
            {
                return handler
                    .ReadJwtToken(bearerToken)
                    .Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "userId")?.Value ?? string.Empty;
            }
        }

        return string.Empty;
    }
}