using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class ThemeConfig: IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Course)
                .WithMany(p => p.Themes)
                .HasForeignKey(p => p.CourseId);

            builder.HasOne(p => p.Level)
                .WithMany(p => p.Themes)
                .HasForeignKey(p => p.LevelId);

            builder.HasMany(p => p.Themes)
                .WithOne(p => p.Parent)
                .IsRequired(false)
                .HasForeignKey(p => p.ParentId);
        }
    }
}
