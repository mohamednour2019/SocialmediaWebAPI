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
    public class UserRefreshTokenConfiguratinos:IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.ToTable("UsersRefreshTokens");
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.User)
                .WithOne(x => x.RefreshToken)
                .HasForeignKey<UserRefreshToken>(x => x.UserId);
        }
    }
}
