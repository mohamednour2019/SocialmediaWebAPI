using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.EntitiesConfigurations.cs
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x=>x.UserId).ValueGeneratedNever();
            builder.Property(x=>x.PostId).ValueGeneratedNever();
            builder.HasKey(x =>x.Id);
        }
    }
}
