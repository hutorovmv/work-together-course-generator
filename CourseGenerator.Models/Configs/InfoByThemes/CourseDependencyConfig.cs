using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class CourseDependencyConfig: IEntityTypeConfiguration<CourseDependency>
    {
        public void Configure(EntityTypeBuilder<CourseDependency> builder)
        {
            builder.HasKey(p => new { p.CourseId, p.BaseCourseId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.Course)
                    .WithMany(p => p.CourseDependencies)
                    .HasForeignKey(p => p.CourseId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.BaseCourse)
                    .WithMany(p => p.BaseCourseDependencies)
                    .HasForeignKey(p => p.BaseCourseId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
