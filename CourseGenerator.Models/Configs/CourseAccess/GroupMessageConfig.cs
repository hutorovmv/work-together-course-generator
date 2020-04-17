using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class GroupMessageConfig: IEntityTypeConfiguration<GroupMessage>
    {
        public void Configure(EntityTypeBuilder<GroupMessage> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.GroupMessages)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Sender)
                .WithMany(p => p.GroupMessages)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
