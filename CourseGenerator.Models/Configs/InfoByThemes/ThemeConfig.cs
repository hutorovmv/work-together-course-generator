using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Configs.InfoByThemes
{
    public class ThemeConfig: IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Note).IsUnicode();
            builder.Property(p => p.Number).IsRequired();

            builder.HasOne(p => p.Course)
                .WithMany(p => p.Themes)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Level)
                .WithMany(p => p.Themes)
                .HasForeignKey(p => p.LevelNumber)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.Themes)
                .WithOne(p => p.Parent)
                .IsRequired(false)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.Themes)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
