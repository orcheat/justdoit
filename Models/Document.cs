using System;

namespace todolist.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int TaskId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
