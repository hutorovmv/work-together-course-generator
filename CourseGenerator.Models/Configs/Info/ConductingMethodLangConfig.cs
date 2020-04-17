using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Info
{
    public class ConductingMethodLangConfig: IEntityTypeConfiguration<ConductingMethodLang>
    {
        public void Configure(EntityTypeBuilder<ConductingMethodLang> builder)
        {
            builder.HasKey(p => new { p.ConductingMethodId, p.LangCode });
            builder.Property(p => p.Name).IsUnicode();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Language)
                .WithMany(p => p.ConductingMethodLangs)
                .HasForeignKey(p => p.LangCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ConductingMethod)
                .WithMany(p => p.ConductingMethodLangs)
                .HasForeignKey(p => p.ConductingMethodId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
