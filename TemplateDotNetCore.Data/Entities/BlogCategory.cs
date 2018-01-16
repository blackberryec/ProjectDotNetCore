using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("BlogCategories")]
    public class BlogCategory : DomainEntity<int>, IHasStatus, IHasSeoMetaData, IHasTag,IDateTracking
    {
        public BlogCategory()
        {
            Blogs = new List<Blog>();
        }
        public Status Status { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public string Tags { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }


        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        public string Content { set; get; }

        public virtual ICollection<Blog> Blogs { set; get; }
    }
}