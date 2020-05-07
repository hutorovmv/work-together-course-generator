using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseGenerator.Models.Configs.Info
{
    public class MaterialOrganizationFormConfig: IEntityTypeConfiguration<MaterialOrganizationForm>
    {
        public void Configure(EntityTypeBuilder<MaterialOrganizationForm> builder)
        {
            builder.HasKey(p => new { p.MaterialId, p.OrganizationFormId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.OrganizationForm)
                .WithMany(p => p.MaterialOrganizationForms)
                .HasForeignKey(p => p.OrganizationFormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.MaterialOrganizationForms)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
