using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialConductingMethodConfig: IEntityTypeConfiguration<MaterialConductingMethod>
    {
        public void Configure(EntityTypeBuilder<MaterialConductingMethod> builder)
        {
            builder.HasKey(p => new { p.MaterialId, p.ConductingMethodId });

            builder.HasOne(p => p.ConductingMethod)
                .WithMany(p => p.MaterialConductingMethods)
                .HasForeignKey(p => p.ConductingMethodId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.MaterialConductingMethods)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
