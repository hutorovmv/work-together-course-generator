using CourseGenerator.Models.Entities.InfoByThemes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class CourseDependencyKindConfig: IEntityTypeConfiguration<CourseDependencyKind>
    {
        public void Configure(EntityTypeBuilder<CourseDependencyKind> builder)
        {
            builder.HasKey(p => p.CourseDependencyCode);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Note).IsUnicode();
        }
    }
}
