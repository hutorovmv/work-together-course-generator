using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserMaterialConfig: IEntityTypeConfiguration<UserMaterial>
    {
        public void Configure(EntityTypeBuilder<UserMaterial> builder)
        {
            builder.HasKey(p => new { p.UserId, p.MaterialId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserMaterials)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.UserMaterials)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
