using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseGenerator.Models.Configs.Info
{
    public class OrganizationFormLangConfig: IEntityTypeConfiguration<OrganizationFormLang>
    {
        public void Configure(EntityTypeBuilder<OrganizationFormLang> builder)
        {
            builder.HasKey(p => new { p.OrganizationFormId, p.LangCode });
            builder.Property(p => p.Name).IsUnicode();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.OrganizationForm)
                .WithMany(p => p.OrganizationFormLangs)
                .HasForeignKey(p => p.OrganizationFormId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Language)
                .WithMany(p => p.OrganizationFormLangs)
                .HasForeignKey(p => p.LangCode)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
