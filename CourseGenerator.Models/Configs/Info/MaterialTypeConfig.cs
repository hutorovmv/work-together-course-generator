using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialTypeConfig : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Note).IsUnicode();

            builder.HasMany(p => p.MaterialTypes)
                .WithOne(p => p.Parent)
                .IsRequired(false)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}