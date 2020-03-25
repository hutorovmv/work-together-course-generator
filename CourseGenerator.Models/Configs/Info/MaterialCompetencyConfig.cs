using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialCompetencyConfig : IEntityTypeConfiguration<MaterialCompetency>
    {
        public void Configure(EntityTypeBuilder<MaterialCompetency> builder)
        {
            builder.HasKey(p => new { p.MaterialId, p.CompetencyId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Material)
                .WithMany(p => p.MaterialCompetencies)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Competency)
                .WithMany(p => p.MaterialCompetencies)
                .HasForeignKey(p => p.CompetencyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}