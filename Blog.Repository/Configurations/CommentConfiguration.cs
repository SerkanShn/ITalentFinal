﻿using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x=>x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
