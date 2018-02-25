using System;
using System.Collections.Generic;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.Enums;

namespace TemplateDotNetCore.Application.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

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
        public virtual ICollection<ProductViewModel> Products { set; get; }
    }
}