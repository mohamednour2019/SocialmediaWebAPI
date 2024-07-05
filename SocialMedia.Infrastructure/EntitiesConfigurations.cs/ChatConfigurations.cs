using Microsoft.Diagnostics.Tracing.Parsers.Kernel;
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
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.Property(x=>x.FirstUserId).ValueGeneratedNever();
            builder.Property(x=>x.SecondUserId).ValueGeneratedNever();
            builder.HasKey(x => new {x.FirstUserId, x.SecondUserId });
            builder.HasOne(x => x.Message).WithMany(x => x.Chat).HasForeignKey(x => x.LastMessegeId);
            builder.HasOne(x=>x.FirstUser).WithMany(x=>x.FirstUserChats).HasForeignKey(x=>x.FirstUserId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(x => x.SecondUser).WithMany(x => x.SecondUserChats).HasForeignKey(x => x.SecondUserId).OnDelete(DeleteBehavior.Restrict); ;

        }
    }
}
