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
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(x => x.Posts).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true);

            builder.Property(x => x.ProfilePicture).HasColumnType("image");

            builder.HasMany(x=>x.Comments).WithOne(x => x.User) .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Like).WithOne(x => x.User).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Notifications).WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);


        }
    }
}
