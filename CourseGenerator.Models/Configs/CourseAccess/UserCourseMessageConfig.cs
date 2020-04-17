using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserCourseMessageConfig: IEntityTypeConfiguration<UserCourseMessage>
    {
        public void Configure(EntityTypeBuilder<UserCourseMessage> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserCourseMessages)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Course)
                .WithMany(p => p.UserCourseMessages)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Sender)
                .WithMany(p => p.SenderCourseMessages)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
