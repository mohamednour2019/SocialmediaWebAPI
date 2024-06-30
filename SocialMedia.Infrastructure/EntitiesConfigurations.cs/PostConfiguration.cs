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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x=>x.Id).ValueGeneratedNever();
            builder.Property(x => x.Content).IsRequired(false);

            builder.HasMany(x=>x.Comments).WithOne(x=>x.Post).HasForeignKey(x=>x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x=>x.Likes).WithOne(x=>x.Post).HasForeignKey(x=>x.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.SharedFromUser).WithMany(x => x.SharedPosts)
                .HasForeignKey(x => x.ShareFromUserId).IsRequired(false);
        }
    }
}
