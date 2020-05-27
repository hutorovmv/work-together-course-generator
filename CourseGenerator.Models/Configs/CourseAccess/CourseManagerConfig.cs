using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class CourseManagerConfig : IEntityTypeConfiguration<CourseManager>
    {
        public void Configure(EntityTypeBuilder<CourseManager> builder)
        {
            builder.HasKey(p => new { p.UserId, p.CourseId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Course)
                .WithMany(p => p.CourseManagers)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.User)
                .WithMany(p => p.CourseManagers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
