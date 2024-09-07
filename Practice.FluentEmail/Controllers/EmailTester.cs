using Microsoft.AspNetCore.Mvc;
using Practice.FluentEmail.Common.Utils;
using Practice.FluentEmail.Domain;
using Practice.FluentEmail.Services.Abstractions;

namespace Practice.FluentEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTester(IEmailServices emailServices, IHtmlGenerator generator) : ControllerBase
    {
		private readonly string Template_Path = Path.Combine(Environment.CurrentDirectory, $"Template\\SampleTemplate.cshtml");
		private readonly string Attachment_Path = Path.Combine(Environment.CurrentDirectory, $"Attachment\\SamplePDF.pdf");
		private readonly string To_Email = "19522102@gm.uit.edu.vn";
		private readonly string Email_Subject = "Testing email";

		[HttpGet("sample")]
        public async Task<IActionResult> SendSingleEmail()
		{
			var body = await generator.GenerateHtmlAsync(Template_Path, null);

			await emailServices.Send(new EmailMetadata()
			{
				ToAddress = To_Email,
				Subject = Email_Subject,
				Body = body
			}, true);

            return Ok();
        }

		[HttpGet("sample-with-attachment")]
		public async Task<IActionResult> SendEmailWithAttachment()
		{
			var body = await generator.GenerateHtmlAsync(Template_Path, null);

			var data = new EmailMetadata()
			{
				ToAddress = To_Email,
				Subject = Email_Subject,
				Body = body,
				Attachment = FileReader.New().Read(new FileMetadata()
				{
					FileId = Guid.NewGuid().ToString(),
					FileName = "Sample File",
					FilePath = Attachment_Path
				})
			};

			await emailServices.SendWithAttachment(data, true);

			// Need to close stream thread
			data.Attachment.Data.Close();

			return Ok();
		}
	}
}
