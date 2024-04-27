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
    public class FriendConfigurations : IEntityTypeConfiguration<FriendsRelationship>
    {
        public void Configure(EntityTypeBuilder<FriendsRelationship> builder)
        {
            builder.ToTable("Friends");
            builder.Property(x=>x.FirstUserId).ValueGeneratedNever();
            builder.Property(x => x.SecondUserId).ValueGeneratedNever();
            builder.HasOne(x => x.FirstUser).WithMany(x => x.FirstUserFriends)
                .HasForeignKey(x => x.FirstUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SecondUser).WithMany(x => x.SecondUserFriends)
                .HasForeignKey(x => x.SecondUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasKey(x => new { x.FirstUserId, x.SecondUserId });
        }
    }
}
