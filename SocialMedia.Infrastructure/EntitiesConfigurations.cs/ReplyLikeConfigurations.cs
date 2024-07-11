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
    public class ReplyLikeConfigurations : IEntityTypeConfiguration<ReplyLike>
    {
        public void Configure(EntityTypeBuilder<ReplyLike> builder)
        {
            builder.Property(x => x.UserId).ValueGeneratedNever();
            builder.Property(x => x.ReplyId).ValueGeneratedNever();
            builder.HasKey(x => new { x.UserId, x.ReplyId });

            builder.HasOne(x => x.User).WithMany(x => x.ReplyLikes).HasForeignKey(x => x.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.Reply).WithMany(x => x.ReplyLikes).HasForeignKey(x => x.ReplyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
