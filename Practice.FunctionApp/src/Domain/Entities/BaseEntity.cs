using Newtonsoft.Json;

namespace FunctionApp.IsolatedDemo.Api.Domain.Entities;

public abstract class BaseEntity
{
    [JsonProperty("id")]
    public Guid Id { get; } = Guid.NewGuid();
}
