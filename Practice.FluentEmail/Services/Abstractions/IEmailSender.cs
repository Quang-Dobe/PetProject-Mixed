using Practice.FluentEmail.Domain;

namespace Practice.FluentEmail.Services.Abstractions
{
    public interface IEmailSender
    {
        Task Send(EmailMetadata emailMetadata, bool isHtml = false);

        Task SendWithAttachment(EmailMetadata emailMetadata, bool isHtml = false);
	}
}
