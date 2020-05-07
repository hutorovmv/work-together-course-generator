using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class HeadingManagerConfig : IEntityTypeConfiguration<HeadingManager>
    {
        public void Configure(EntityTypeBuilder<HeadingManager> builder)
        {
            builder.HasKey(p => new { p.UserId, p.HeadingId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.HeadingManagers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.HeadingManagers)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
