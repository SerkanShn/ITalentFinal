using Blog.Core.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CommentDTO
    {
        public bool IsPublish { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public int PostId { get; set; }

    }
}
