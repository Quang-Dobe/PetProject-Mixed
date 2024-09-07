namespace Practice.FluentEmail.Domain
{
	public class FileMetadata
	{
		public required string FileId { get; set; }

		public required string FileName { get; set; }

		public string? FileType { get; set; }

		public string? FilePath { get; set; }
	}
}
