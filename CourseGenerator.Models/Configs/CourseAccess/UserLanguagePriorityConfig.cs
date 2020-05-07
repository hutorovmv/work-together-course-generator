using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserLanguagePriorityConfig : IEntityTypeConfiguration<UserLanguagePriority>
    {
        public void Configure(EntityTypeBuilder<UserLanguagePriority> builder)
        {
            builder.HasKey(p => new { p.UserId, p.LangCode });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserLanguagePriorities)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Language)
                .WithMany(p => p.UserLanguagePriorities)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
