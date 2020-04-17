using CourseGenerator.Models.Entities.Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Configs.Info
{
    public class OrganizationFormConfig: IEntityTypeConfiguration<OrganizationForm>
    {
        public void Configure(EntityTypeBuilder<OrganizationForm> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Parent)
                .WithMany(p => p.OrganizationForms)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
