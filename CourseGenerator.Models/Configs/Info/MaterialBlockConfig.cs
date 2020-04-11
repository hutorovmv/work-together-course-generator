using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialBlockConfig: IEntityTypeConfiguration<MaterialBlock>
    {
        public void Configure(EntityTypeBuilder<MaterialBlock> builder)
        {
            builder.HasKey(p => new { p.ParentId, p.ChildId });
            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.ParentMaterial)
                .WithMany(p => p.MaterialBlocksParent)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.ChildMaterial)
                .WithMany(p => p.MaterialBlocksChild)
                .HasForeignKey(p => p.ChildId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
