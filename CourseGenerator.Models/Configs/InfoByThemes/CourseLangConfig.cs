using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class CourseLangConfig: IEntityTypeConfiguration<CourseLang>
    {
        public void Configure(EntityTypeBuilder<CourseLang> builder)
        {
            builder.HasKey(p => new { p.CourseId, p.LangId });
            builder.Property(p => p.Description).IsUnicode();
            builder.Property(p => p.Name).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.CourseLangs)
                .HasForeignKey(p => p.LangId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Course)
                .WithMany(p => p.CourseLangs)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
