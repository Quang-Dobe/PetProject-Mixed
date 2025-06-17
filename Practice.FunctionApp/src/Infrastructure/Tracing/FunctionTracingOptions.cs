namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;

internal class FunctionTracingOptions
{
    public bool Enable { get; set; } = true;

    public string ContextKeys { get; set; } = string.Empty;

    public string PropNamePrefix { get; set; } = "props__";
}
