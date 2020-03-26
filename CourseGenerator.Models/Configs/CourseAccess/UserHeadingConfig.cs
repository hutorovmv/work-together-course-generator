using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserHeadingConfig: IEntityTypeConfiguration<UserHeading>
    {
        public void Configure(EntityTypeBuilder<UserHeading> builder)
        {
            builder.HasKey(p => new { p.UserId, p.HeadingId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserHeadings)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.UserHeadings)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Level)
                .WithMany(p => p.UserHeading)
                .HasForeignKey(p => p.LevelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
