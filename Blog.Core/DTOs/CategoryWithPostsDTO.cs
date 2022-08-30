﻿using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.DTOs
{
    public class CategoryWithPostsDTO
    {
        public string Title { get; set; }
        public List<PostDTO> Posts { get; set; }
    }
}
