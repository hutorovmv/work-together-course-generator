using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Configs.Info
{
    public class LevelConfig : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(p => p.Number);

            builder.Property(p => p.Note).IsUnicode();
        }
    }
}