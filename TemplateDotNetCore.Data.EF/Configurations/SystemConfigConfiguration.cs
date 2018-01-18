using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class SystemConfigConfiguration : ModelBuilderExtensions.DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}