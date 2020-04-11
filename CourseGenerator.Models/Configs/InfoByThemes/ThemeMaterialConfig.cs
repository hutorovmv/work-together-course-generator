using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class ThemeMaterialConfig: IEntityTypeConfiguration<ThemeMaterial>
    {
        public void Configure(EntityTypeBuilder<ThemeMaterial> builder)
        {
            builder.HasKey(p => new { p.ThemeId, p.MaterialId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Theme)
                .WithMany(p => p.ThemeMaterials)
                .HasForeignKey(p => p.ThemeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.ThemeMaterials)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Level)
                .WithMany(p => p.ThemeMaterials)
                .HasForeignKey(p => p.LevelId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
