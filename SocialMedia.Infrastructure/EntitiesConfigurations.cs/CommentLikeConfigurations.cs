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
    public class CommentLikeConfigurations : IEntityTypeConfiguration<CommentLike>
    {
        public void Configure(EntityTypeBuilder<CommentLike> builder)
        {
            builder.Property(x=>x.UserId).ValueGeneratedNever();
            builder.Property(x => x.CommentId).ValueGeneratedNever();
            builder.HasKey(x => new { x.UserId, x.CommentId });

            builder.HasOne(x => x.User)
                   .WithMany(x => x.CommentLikes)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Comment)
                   .WithMany(x => x.Likes)
                   .HasForeignKey(x => x.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
