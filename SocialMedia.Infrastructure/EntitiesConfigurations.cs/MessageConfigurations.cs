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
    public class MessageConfigurations : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(x=>x.SenderId).ValueGeneratedNever();
            builder.Property(x=>x.ReciverId).ValueGeneratedNever();

            builder.HasOne(x=>x.Sender).WithMany(x=>x.SenderMessages).HasForeignKey(x=>x.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Reciver).WithMany(x=>x.ReciverMessages).HasForeignKey(x=>x.ReciverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(x =>x.Id);

        }
    }
}
