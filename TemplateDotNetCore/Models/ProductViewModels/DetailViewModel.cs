using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Application.ViewModels.Common;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Models.ProductViewModels
{
    public class DetailViewModel
    {
        public ProductViewModel Product { get; set; }

        public bool Available { set; get; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public List<ProductViewModel> UpsellProducts { get; set; }

        public List<ProductViewModel> LastestProducts { get; set; }

        public List<TagViewModel> Tags { set; get; }

        public List<SelectListItem> Colors { set; get; }

        public List<ProductViewModel> ProductList { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}