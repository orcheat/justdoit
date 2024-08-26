using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace todolist.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { get; set; }

        public string Category { get; set; }
        public int CategoryId { get; set; }  // Foreign Key

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Document> Documents { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}