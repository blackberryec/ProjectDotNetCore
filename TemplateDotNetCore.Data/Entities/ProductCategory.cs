using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, IHasStatus, IMultiLanguage, IHasTag,IDateTracking, ISortable, IHasStatusFlag
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string name, string discription,int? parentId, int? homeOrder, string image, string seoPageTitle, string seoAlias,string seoKeywords,string seoDescription,
            Status status,int languageId, string tags, DateTime dateCreated, DateTime dateModified,int sortOrder, bool? homeFlag, bool? hotFlag, bool? newflag)
        {
            Name = name;
            Discription = discription;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            Status = status;
            LanguageId = languageId;
            Tags = tags;
            DateCreated = dateCreated;
            DateModified = dateModified;
            SortOrder = sortOrder;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            NewFlag = newflag;
        }

        public string Name { get; set; }

        public string Discription { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public Status Status { get; set; }

        public int LanguageId { get; set; }

        public string Tags { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }


        public int SortOrder { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public bool? NewFlag { get; set; }


        /*
         Sử dụng ICollection thay cho IEnumerable vì enum chỉ có thể đọc, 
         Collection ta có thể điều chỉnh va khi sử dụng Collection entity có thể null,
         khắc phục bằng cách tạo mới entity đó ở contructor 
        */
        public virtual ICollection<Product> Products { set; get; }
    }
}