using FluentEmail.Core;
using Practice.FluentEmail.Domain;
using Practice.FluentEmail.Services.Abstractions;

namespace Practice.FluentEmail.Services.Implementations
{
    public class FluentEmailSender(IFluentEmail fluentEmail) : IEmailSender
    {
        public async Task Send(EmailMetadata emailMetadata, bool isHtml = false)
        {
            await fluentEmail
                .To(emailMetadata.ToAddress)
                .Subject(emailMetadata.Subject)
                .Body(emailMetadata.Body, isHtml)
                .SendAsync();
        }

        public async Task SendWithAttachment(EmailMetadata emailMetadata, bool isHtml = false)
        {
			await fluentEmail
				.To(emailMetadata.ToAddress)
				.Subject(emailMetadata.Subject)
				.Body(emailMetadata.Body, isHtml)
                .Attach(emailMetadata.Attachment)
				.SendAsync();
		}
    }
}
