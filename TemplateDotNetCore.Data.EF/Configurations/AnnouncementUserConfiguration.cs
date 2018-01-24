using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class AnnouncementUserConfiguration : ModelBuilderExtensions.DbEntityConfiguration<AnnouncementUser>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementUser> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(128).IsRequired();
        }
    }
}