using System.Threading.Tasks;
using System;

namespace todolist.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

        public Task Task { get; set; }
    }

}
