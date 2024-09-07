namespace Practice.FluentEmail.Common
{
	public static class Constants
	{
		public static class ErrorMessage
		{
			public static string NOT_SUPPORT = "This {0} is not supported";
		}

		public static class File
		{
			public static Dictionary<string, string> ContentTypeDic = new Dictionary<string, string>()
			{
				{ "pdf", "application/pdf" },
				{ "doc", "application/msword" },
				{ "xls", "application/vnd.ms-excel" },
				{ "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
				{ "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
			};
		}

	}
}
