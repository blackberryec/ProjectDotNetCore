using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TemplateDotNetCore.Data.EF.Extensions
{

    /*
     You can override the OnModelCreating method in your derived context and
     use the ModelBuilder API to configure your model. 
     This is the most powerful method of configuration and allows configuration 
     to be specified without modifying your entity classes.

     Ví dụ 2 entity như productTag và Tag 
     có Id cần trung kiểu dữ liệu ta sử dụng 
     TagConfiguration xác định rỏ kiểu cho id 
     trong các trường hợp đặc biệt khác dữ liệu với nhau,
     và các trường hợp không config được bằng anotation ta sử dụng cách này. ( complex data model ) (Fluent API)
    */
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(
            this ModelBuilder modelBuilder,
            DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }

        public abstract class DbEntityConfiguration<TEntity> where  TEntity : class
        {
            public abstract void Configure(EntityTypeBuilder<TEntity> entity);
        }
    }
}