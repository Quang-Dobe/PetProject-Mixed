using Practice.FluentEmail.Domain;
using Practice.FluentEmail.Services.Abstractions;

namespace Practice.FluentEmail.Services.Implementations
{
    public class EmailServices(IEmailSender emailSender) : BaseServices, IEmailServices
    {
        public async Task Send(EmailMetadata emailMetadata, bool isHtml = false)
        {
            await emailSender.Send(emailMetadata, isHtml);
        }

        public async Task SendWithAttachment(EmailMetadata emailMetadata, bool isHtml = false)
        {
            await emailSender.SendWithAttachment(emailMetadata, isHtml);
        }

	}
}
