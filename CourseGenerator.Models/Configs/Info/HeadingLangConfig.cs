using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class HeadingLangConfig : IEntityTypeConfiguration<HeadingLang>
    {
        public void Configure(EntityTypeBuilder<HeadingLang> builder)
        {
            builder.HasKey(p => new { p.HeadingId, p.LangCode });

            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.Description).IsUnicode();

            builder.HasOne(p => p.Lang)
                .WithMany(p => p.HeadingLangs)
                .HasForeignKey(p => p.LangCode)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Heading)
                .WithMany(p => p.HeadingLangs)
                .HasForeignKey(p => p.HeadingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}