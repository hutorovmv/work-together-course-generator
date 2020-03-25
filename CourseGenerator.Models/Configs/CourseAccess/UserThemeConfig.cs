using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserThemeConfig: IEntityTypeConfiguration<UserTheme>
    {
        public void Configure(EntityTypeBuilder<UserTheme> builder)
        {
            builder.HasKey(p => new { p.UserId, p.ThemeId });
            builder.Property(p => p.Note);
            builder.Property(p => p.Grade);

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserThemes)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Theme)
                .WithMany(p => p.UserThemes)
                .HasForeignKey(p => p.ThemeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Level)
                .WithMany(p => p.UserThemes)
                .HasForeignKey(p => p.LevelId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
