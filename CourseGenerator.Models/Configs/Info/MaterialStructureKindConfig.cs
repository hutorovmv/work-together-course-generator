using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialStructureKindConfig: IEntityTypeConfiguration<MaterialStructureKind>
    {
        public void Configure(EntityTypeBuilder<MaterialStructureKind> builder)
        {
            builder.HasKey(p => p.MaterialStructureCode);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Note).IsUnicode();
        }
    }
}
