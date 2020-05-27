using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class HeadingMaterialConfig : IEntityTypeConfiguration<HeadingMaterial>
    {
        public void Configure(EntityTypeBuilder<HeadingMaterial> builder)
        {
            builder.HasKey(p => new { p.HeadingId, p.MaterialId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.HeadingMaterials)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.HeadingMaterials)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}