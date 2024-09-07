using FluentEmail.Core.Models;
using Practice.FluentEmail.Domain;

namespace Practice.FluentEmail.Common.Utils
{
	public class FileReader
	{
		private FileReader() { }

		public static FileReader New() => new();

		public Stream ReadStreamFromPath(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return default;
			}

			return new FileStream(filePath, FileMode.Open);
		}

		public byte[] ReadBytesFromPath(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return default;
			}

			return File.ReadAllBytes(filePath);
		}

		public string ReadFileType(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return string.Empty;
			}

			return filePath.Split(".").LastOrDefault() ?? string.Empty;
		}

		public string ReadContentType(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				return string.Empty;
			}

			var fileType = ReadFileType(filePath).ToLower();

			if (Constants.File.ContentTypeDic.TryGetValue(fileType, out var contentType))
			{
				return contentType;
			}

			throw new NotSupportedException(string.Format(Constants.ErrorMessage.NOT_SUPPORT, "file's type"));
		}

		public Attachment Read(FileMetadata file)
		{
			var bytesData = ReadBytesFromPath(file.FilePath);
			var contentType = ReadContentType(file.FilePath);

			var data = new Attachment()
			{
				ContentId = file.FileId,
				Filename = file.FileName,
				ContentType = contentType,
				Data = new MemoryStream(bytesData),
				IsInline = false
			};

			return data;
		}
	}
}
