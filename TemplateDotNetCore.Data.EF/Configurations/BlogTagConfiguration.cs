using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNetCore.Data.EF.Extensions;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Data.EF.Configurations
{
    public class BlogTagConfiguration : ModelBuilderExtensions.DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.Property(c=>c.TagId).HasMaxLength(255).IsRequired()
                .HasColumnType("varchar(255)");
        }
    }
}