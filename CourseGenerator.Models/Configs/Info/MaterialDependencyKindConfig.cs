using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialDependencyKindConfig: IEntityTypeConfiguration<MaterialDependencyKind>
    {
        public void Configure(EntityTypeBuilder<MaterialDependencyKind> builder)
        {
            builder.HasKey(p => p.MaterialDependencyCode);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Note).IsUnicode();
        }
    }
}
