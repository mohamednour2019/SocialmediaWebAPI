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
    public class MessengerHubConfigurations : IEntityTypeConfiguration<MessengerHub>
    {
        public void Configure(EntityTypeBuilder<MessengerHub> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.User).WithOne(x => x.MessengerHub)
                .HasForeignKey<MessengerHub>(x => x.UserId);
        }
    }
}
