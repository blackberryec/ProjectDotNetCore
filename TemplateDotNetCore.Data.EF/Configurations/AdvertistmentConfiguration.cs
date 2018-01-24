using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class AdvertistmentConfiguration : ModelBuilderExtensions.DbEntityConfiguration<Advertistment>
    {
        public override void Configure(EntityTypeBuilder<Advertistment> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}