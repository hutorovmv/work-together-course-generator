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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.MaterialTypeLangs)
                .HasForeignKey(p => p.LangId);
        }
    }
}