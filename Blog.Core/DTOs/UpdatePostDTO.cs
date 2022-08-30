using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public string PostContent { get; set; }
        public bool IsPublish { get; set; }
        public DateTime? EditedOn { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}
