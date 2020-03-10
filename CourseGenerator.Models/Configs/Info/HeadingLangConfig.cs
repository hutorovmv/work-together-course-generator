using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class HeadingLangConfig : IEntityTypeConfiguration<HeadingLang>
    {
        public void Configure(EntityTypeBuilder<HeadingLang> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.HeadingLangs)
                .HasForeignKey(p => p.LangId);
        }
    }
}