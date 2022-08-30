using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CreateCommentDTO
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsPublish { get; set; } = true;

        public string Title { get; set; }
        public string CommentContent { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
