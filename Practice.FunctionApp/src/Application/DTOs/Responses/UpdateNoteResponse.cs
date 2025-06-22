namespace FunctionApp.IsolatedDemo.Api.Application.DTOs.Responses
{
	internal class UpdateNoteResponse
	{
		public string Title { get; set; } = default!;

		public string Body { get; set; } = default!;

		public DateTime LastUpdatedOn { get; set; }
	}
}
