using CourseGenerator.Models.Entities.CourseAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.CourseAccess
{
    public class UserMaterialMessageConfig: IEntityTypeConfiguration<UserMaterialMessage>
    {
        public void Configure(EntityTypeBuilder<UserMaterialMessage> builder)
        {
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Message).IsUnicode();

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserMaterialMessages)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Material)
                .WithMany(p => p.UserMaterialMessages)
                .HasForeignKey(p => p.MaterialId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Sender)
                .WithMany(p => p.SenderMessages)
                .HasForeignKey(p => p.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
