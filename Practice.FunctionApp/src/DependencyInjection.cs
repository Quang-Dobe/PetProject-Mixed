using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;
using System.Net.Http;
using Microsoft.Azure.Cosmos;
using FunctionApp.IsolatedDemo.Api.Infrastructure.Tracing;
using FunctionApp.IsolatedDemo.Api.Infrastructure.Provider;
using FunctionApp.IsolatedDemo.Api.Services;
using FunctionApp.IsolatedDemo.Api.Persistence;
using FunctionApp.IsolatedDemo.Api.Persistence.Repositories;

namespace FunctionApp.IsolatedDemo.Api;

internal static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<FunctionTraceContextProvider>();

        services
            .AddHttpClient<INotificationService, NotificationService>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("NotificationApiUrl"));
            })
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());

        return services;
    }

	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var cosmosClient = new CosmosClient(configuration["Cosmos:ConnectionString"]);
        var databaseName = configuration["Cosmos:DatabaseName"];
        var containerName = configuration["Cosmos:ContainerName"];

        services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(cosmosClient, databaseName, containerName));
        services.AddSingleton<INoteRepository, NoteRepository>();

        return services;
    }

	public static IServiceCollection AddServices(this IServiceCollection services, IConfigurationRoot configuration)
	{
		services.AddScoped<INoteService, NoteService>();

		return services;
	}

	private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrTransientHttpStatusCode()
            .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrTransientHttpStatusCode()
            .CircuitBreakerAsync(3, TimeSpan.FromMinutes(2));
    }
}
