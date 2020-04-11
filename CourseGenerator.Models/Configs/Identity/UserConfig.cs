using CourseGenerator.Models.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Identity
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(p => p.PhoneNumber).IsUnique();

            builder.HasOne(p => p.PreferedLang)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.PreferedLangCode)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}