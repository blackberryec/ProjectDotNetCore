using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TemplateDotNetCore.Data.Enums;
using TemplateDotNetCore.Data.Interfaces;
using TemplateDotNetCore.Infrastucture.SharedKernel;

namespace TemplateDotNetCore.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, IHasStatus, IDateTracking, IHasSeoMetaData, IBasicInfo, IHasPrice, IHasStatusFlag, IHasTag, IMultiLanguage, IHasGuarantee
    {
        public Product()
        {
            ProductTags = new List<ProductTag>();
        }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal Sold { get; set; }

        public DateTime DateModified { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public string Size { get; set; }

        public string SeoPageTitle { get; set; }

        [Column(TypeName = "varchar(255)")]
        [StringLength(255)]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public decimal? PromotionPrice { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }
        public bool? NewFlag { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        public int LanguageId { get; set; }

        public DateTime PurchaseTime { get; set; }

        public DateTime ErrorTime { get; set; }

        public int Warranty { get; set; }

        public double Quantity { get; set; }

        public int Star { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }

    }
}