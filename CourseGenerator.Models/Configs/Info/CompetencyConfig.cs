using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class CompetencyConfig : IEntityTypeConfiguration<Competency>
    {
        public void Configure(EntityTypeBuilder<Competency> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Level)
                .WithMany(p => p.Competencies)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Competencies)
                .WithOne(p => p.Parent)
                .IsRequired(false)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
