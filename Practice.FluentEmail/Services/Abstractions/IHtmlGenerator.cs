namespace Practice.FluentEmail.Services.Abstractions
{
    public interface IHtmlGenerator
    {
        Task<string> GenerateHtmlAsync(string path, object model);
    }
}
