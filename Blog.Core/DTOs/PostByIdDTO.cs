using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostByIdDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public string PostContent { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
