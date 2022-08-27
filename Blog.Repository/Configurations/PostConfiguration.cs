using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title)
                   .HasMaxLength(100);
            builder.Property(p => p.Summary)
                    .HasMaxLength(450);
            builder.Property(p => p.PostBanner)
                    .HasMaxLength(250);
            builder.Property(p => p.EditedOn)
                    .IsRequired(false);
            builder.Property(p => p.PostBanner)
                   .IsRequired(false);
        }
    }
}
