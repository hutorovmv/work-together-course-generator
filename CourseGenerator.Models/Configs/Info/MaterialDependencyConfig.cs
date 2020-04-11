using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialDependencyConfig: IEntityTypeConfiguration<MaterialDependency>
    {
        public void Configure(EntityTypeBuilder<MaterialDependency> builder)
        {
            builder.HasKey(p => new { p.BaseMaterialId, p.MaterialId });

            builder.HasOne(p => p.Material)
                .WithMany(p => p.MaterialDependencies)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.BaseMaterial)
                .WithMany(p => p.BaseMaterialDependencies)
                .HasForeignKey(p => p.BaseMaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
