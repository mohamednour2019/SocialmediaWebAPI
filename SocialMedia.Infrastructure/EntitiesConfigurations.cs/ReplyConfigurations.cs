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
    public class ReplyConfigurations : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            builder.ToTable("Replies");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.reply).WithMany(x => x.Replies)
                .HasForeignKey(x => x.ReplyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Comment).WithMany(x => x.Replies)
                .HasForeignKey(x => x.CommentId)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ReplyLikes).WithOne(x => x.Reply)
                .HasForeignKey(x => x.ReplyId)
                .IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
