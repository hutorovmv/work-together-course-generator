using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class CourseDependencyConfig: IEntityTypeConfiguration<CourseDependency>
    {
        public void Configure(EntityTypeBuilder<CourseDependency> builder)
        {
            builder.HasKey(p => new { p.CourseId, p.BaseCourseId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Course)
                    .WithMany(p => p.CourseDependencies)
                    .HasForeignKey(p => p.CourseId);

            builder.HasOne(p => p.Course)
                    .WithMany(p => p.CourseDependencies)
                    .HasForeignKey(p => p.BaseCourseId);
        }
    }
}
