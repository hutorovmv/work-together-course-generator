using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialLangConfig : IEntityTypeConfiguration<MaterialLang>
    {
        public void Configure(EntityTypeBuilder<MaterialLang> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.FileUrl).IsUnicode();
            builder.Property(p => p.BackImageLangUrl).IsUnicode();
            builder.Property(p => p.Text).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.MaterialLangs)
                .HasForeignKey(p => p.LangId);
        }
    }
}