using Practice.FluentEmail.Services.Abstractions;
using RazorLight;

namespace Practice.FluentEmail.Services.Implementations
{
    public class HtmlGenerator : IHtmlGenerator
    {
        private readonly IRazorLightEngine _engine;

        public HtmlGenerator(IRazorLightEngine razorLightEngine)
        {
            _engine = razorLightEngine;
        }

        public async Task<string> GenerateHtmlAsync(string path, object model)
        {
            return await _engine.CompileRenderAsync(path, model);
        }
    }
}
