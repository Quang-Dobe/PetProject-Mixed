namespace FunctionApp.IsolatedDemo.Api.Infrastructure.Provider;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}
