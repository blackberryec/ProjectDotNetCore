using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TemplateDotNetCore.Data.Enums;

namespace TemplateDotNetCore.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public decimal Sold { get; set; }

        public DateTime DateModified { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public string Size { get; set; }

        public string SeoPageTitle { get; set; }

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

        public virtual ProductCategoryViewModel ProductCategory { get; set; }
    }
}