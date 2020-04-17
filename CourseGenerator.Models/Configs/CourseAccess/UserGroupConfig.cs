using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserGroupConfig: IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(p => new { p.UserId, p.GroupId });
            builder.Property(p => p.Note).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserGroups)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Group)
                .WithMany(p => p.UserGroups)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
