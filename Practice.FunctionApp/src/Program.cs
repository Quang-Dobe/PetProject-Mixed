using FunctionApp.IsolatedDemo.Api;
using FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
	.ConfigureOpenApi()
	.ConfigureFunctionsWebApplication()
    .ConfigureFunctionsWorkerDefaults((workerBuilder) =>
    {
        workerBuilder.UseFunctionExecutionMiddleware();
        workerBuilder.UseWhen<MonitoringMiddleWare>((context) => true);
    })
	.ConfigureServices(services =>
    {
        var configuration = new ConfigurationBuilder()
                 .SetBasePath(Environment.CurrentDirectory)
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables()
                 .Build();

        services.AddPersistence(configuration);
        services.AddServices(configuration);
		services.AddInfrastructure(configuration);

		services.AddApplicationInsightsTelemetryWorkerService();
		services.Configure(delegate (LoggerFilterOptions opts)
		{
			LoggerFilterRule loggerFilterRule = opts.Rules.FirstOrDefault((LoggerFilterRule r) => r.ProviderName == "Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider");
			if (loggerFilterRule != null)
			{
				opts.Rules.Remove(loggerFilterRule);
				opts.Rules.Add(new LoggerFilterRule("Microsoft.Extensions.Logging.ApplicationInsights.ApplicationInsightsLoggerProvider", loggerFilterRule.CategoryName, LogLevel.Information, null));
			}
		});
	})
	.Build();

await host.RunAsync();