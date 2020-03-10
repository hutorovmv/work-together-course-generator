using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class HeadingConfig : IEntityTypeConfiguration<Heading>
    {
        public void Configure(EntityTypeBuilder<Heading> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.UDC).IsRequired();
            builder.Property(p => p.Note).IsUnicode();
        }
    }
}
