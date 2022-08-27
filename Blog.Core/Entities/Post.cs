using Blog.Core.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public string PostContent { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? EditedOn { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string UserId { get; set; }
        public UserApp User { get; set; }

    }
}
