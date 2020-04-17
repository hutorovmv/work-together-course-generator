using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Info
{
    public class ConductingMethodConfig: IEntityTypeConfiguration<ConductingMethod>
    {
        public void Configure(EntityTypeBuilder<ConductingMethod> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Parent)
                .WithMany(p => p.ConductingMethods)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
