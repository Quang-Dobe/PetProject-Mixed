using Practice.FluentEmail.Services.Abstractions;
using Practice.FluentEmail.Services.Implementations;
using RazorLight;
using System.Reflection;

namespace Practice.FluentEmail.Common
{
    public static class Extensions
    {
        public static IServiceCollection AddFluentEmailSender(this IServiceCollection services, ConfigurationManager configuration)
        {
            var configurationSection = configuration.GetSection("EmailSettings");

            var defaultFromEmail = configurationSection.GetValue<string>("DefaultFromEmail");
            var host = configurationSection.GetValue<string>("Host");
            var port = configurationSection.GetValue<int>("Port");
            var userName = configurationSection.GetValue<string>("UserName");
            var password = configurationSection.GetValue<string>("Password");

            services
                .AddFluentEmail(defaultFromEmail)
                .AddSmtpSender(host, port, userName, password);

            return services;
        }

        public static IServiceCollection AddEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, FluentEmailSender>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseServices, BaseServices>();

            foreach (var exportedType in Assembly.GetExecutingAssembly().GetExportedTypes())
            {
                if (exportedType.IsClass && !exportedType.IsAbstract)
                {
                    var interfaceTypes = exportedType.GetInterfaces();
                    if (interfaceTypes.Length > 1 && interfaceTypes.First().Name.StartsWith("IBaseServices"))
                    {
                        services.AddScoped(interfaceTypes.ElementAtOrDefault(1), exportedType);
                    }
                }
            }

            return services;
        }

        public static IServiceCollection AddHtmlGenerator(this IServiceCollection services)
        {
            var engine = new RazorLightEngineBuilder()
                  .UseFileSystemProject(Environment.CurrentDirectory)
                  .UseMemoryCachingProvider()
                  .Build();

            services.AddSingleton<IRazorLightEngine>(engine);
            services.AddSingleton<IHtmlGenerator, HtmlGenerator>();

            return services;
        }
    }
}
