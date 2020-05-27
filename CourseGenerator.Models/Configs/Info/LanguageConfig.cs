using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(p => p.Code);

            builder.Property(p => p.Name).IsUnicode().IsRequired();
            builder.Property(p => p.OriginalName).IsUnicode().IsRequired();
            builder.Property(p => p.Note).IsUnicode();


        }
    }
}