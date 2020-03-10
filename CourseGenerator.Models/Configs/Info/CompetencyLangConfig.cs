using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class CompetencyLangConfig : IEntityTypeConfiguration<CompetencyLang>
    {
        public void Configure(EntityTypeBuilder<CompetencyLang> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.CompetencyLangs)
                .HasForeignKey(p => p.LangId);
        }
    }
}
