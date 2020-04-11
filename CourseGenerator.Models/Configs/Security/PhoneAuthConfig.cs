using CourseGenerator.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Security
{
    public class PhoneAuthConfig: IEntityTypeConfiguration<PhoneAuth>
    {
        public void Configure(EntityTypeBuilder<PhoneAuth> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.PhoneNumber).IsUnique();

            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.Code).IsRequired();
        }
    }
}
