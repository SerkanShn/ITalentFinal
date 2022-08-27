using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
