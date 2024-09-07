using FluentEmail.Core.Models;

namespace Practice.FluentEmail.Domain
{
    public class EmailMetadata
    {
        public string ToAddress { get; set; }

        public string Subject { get; set; }

        public string? Body { get; set; }

        public Attachment? Attachment { get; set; }

        // This field could be used if we have database
        public string? FileId { get; set; }
    }
}
