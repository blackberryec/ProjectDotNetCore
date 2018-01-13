using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class TagConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(50)
                .IsRequired().HasColumnType("varchar(50)");
        }
    }
}