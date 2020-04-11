using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class ThemeLangConfig : IEntityTypeConfiguration<ThemeLang>
    {
        public void Configure(EntityTypeBuilder<ThemeLang> builder)
        {
            builder.HasKey(p => new { p.ThemeId, p.LangCode });
            builder.Property(p => p.Description).IsUnicode();
            builder.Property(p => p.Name).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.ThemeLangs)
                .HasForeignKey(p => p.LangCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Theme)
                .WithMany(p => p.ThemeLangs)
                .HasForeignKey(p => p.ThemeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
