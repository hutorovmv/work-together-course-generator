using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialTypeLangConfig : IEntityTypeConfiguration<MaterialTypeLang>
    {
        public void Configure(EntityTypeBuilder<MaterialTypeLang> builder)
        {
            builder.HasKey(p => new { p.MaterialTypeId, p.LangId});
            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.MaterialTypeLangs)
                .HasForeignKey(p => p.LangId);

            builder.HasOne(p => p.MaterialType)
                .WithMany(p => p.MaterialTypeLangs)
                .HasForeignKey(p => p.MaterialTypeId);
        }
    }
}