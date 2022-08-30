using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CategoryWithPostsCount
    {
        public string Title { get; set; }
        public int PostCount { get; set; }
    }
}
