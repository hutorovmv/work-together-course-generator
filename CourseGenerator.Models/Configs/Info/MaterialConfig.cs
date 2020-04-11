using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialConfig : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FileUrl).IsUnicode();
            builder.Property(p => p.BackImageUrl).IsUnicode();
            builder.Property(p => p.Url).IsUnicode();
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.MaterialType)
                .WithMany(p => p.Materials)
                .HasForeignKey(p => p.MaterialTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Materials)
                .WithOne(p => p.Parent)
                .IsRequired(false)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}