using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class CourseHeadingConfig: IEntityTypeConfiguration<CourseHeading>
    {
        public void Configure(EntityTypeBuilder<CourseHeading> builder)
        {
            builder.HasKey(p => new { p.CourseId, p.HeadingId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Course)
                .WithMany(p => p.CourseHeadings)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.CourseHeadings)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
