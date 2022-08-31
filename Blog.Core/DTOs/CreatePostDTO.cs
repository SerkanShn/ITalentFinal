using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public string PostContent { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? EditedOn { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; } = "1dd44c94-dd77-4b1d-a9b9-09283538e65a";
    }
}
