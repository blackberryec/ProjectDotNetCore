using System.Collections.Generic;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Data.Entities;

namespace TemplateDotNetCore.Models.ProductViewModels
{
    public class DetailViewModel
    {
        public List<ProductViewModel> ProductList { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}