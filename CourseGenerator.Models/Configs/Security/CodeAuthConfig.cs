using CourseGenerator.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Security
{
    public class CodeAuthConfig : IEntityTypeConfiguration<CodeAuth>
    {
        public void Configure(EntityTypeBuilder<CodeAuth> builder)
        {
            builder.HasKey(p => new { p.Code, p.UserId });
            builder.HasIndex(p => p.UserId).IsUnique();
        }
    }
}
