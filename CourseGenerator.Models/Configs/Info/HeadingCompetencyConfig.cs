using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class HeadingCompetencyConfig : IEntityTypeConfiguration<HeadingCompetency>
    {
        public void Configure(EntityTypeBuilder<HeadingCompetency> builder)
        {
            builder.HasKey(p => new { p.HeadingId, p.CompetencyId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.HeadingCompetencies)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Competency)
                .WithMany(p => p.HeadingCompetencies)
                .HasForeignKey(p => p.CompetencyId);
        }
    }
}