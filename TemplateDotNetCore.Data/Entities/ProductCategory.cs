using System;
using System.Collections.Generic;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, IHasStatus, IMultiLanguage, IHasTag,IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public string SeoPageTitle { get; set; }
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public Status Status { get; set; }
        public int LanguageId { get; set; }
        public string Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        /*
         Sử dụng ICollection thay cho IEnumerable vì enum chỉ có thể đọc, 
         Collection ta có thể điều chỉnh va khi sử dụng Collection entity có thể null,
         khắc phục bằng cách tạo mới entity đó ở contructor 
        */
        public virtual ICollection<Product> Products { set; get; }

    }
}