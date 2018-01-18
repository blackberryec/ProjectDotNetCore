using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class AdvertistmentPositionConfiguration : ModelBuilderExtensions.DbEntityConfiguration<AdvertistmentPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}