using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string? PostBanner { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
