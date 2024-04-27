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
    public class LikeConfigurations : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property(x => x.UserId).ValueGeneratedNever();
            builder.Property(x => x.PostId).ValueGeneratedNever();
            builder.HasKey(x => new { x.UserId, x.PostId });
        }
    }
}
