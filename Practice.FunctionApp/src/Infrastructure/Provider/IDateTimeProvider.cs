namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Provider;

internal interface IDateTimeProvider
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
