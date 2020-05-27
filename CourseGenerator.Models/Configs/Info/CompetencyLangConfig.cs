using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class CompetencyLangConfig : IEntityTypeConfiguration<CompetencyLang>
    {
        public void Configure(EntityTypeBuilder<CompetencyLang> builder)
        {
            builder.HasKey(p => new { p.CompetencyId,  p.LangCode});
            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.CompetencyLangs)
                .HasForeignKey(p => p.LangCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Competency)
                .WithMany(p => p.CompetencyLangs)
                .HasForeignKey(p => p.CompetencyId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
