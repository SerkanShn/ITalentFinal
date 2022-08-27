﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Authentication
{
    public class UserApp : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; }
    }
}
