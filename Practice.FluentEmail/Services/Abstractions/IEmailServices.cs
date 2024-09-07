using Practice.FluentEmail.Domain;

namespace Practice.FluentEmail.Services.Abstractions
{
    public interface IEmailServices : IBaseServices
    {
        Task Send(EmailMetadata emailMetadata, bool isHtml = false);

        Task SendWithAttachment(EmailMetadata emailMetadata, bool isHtml = false);
	}
}
