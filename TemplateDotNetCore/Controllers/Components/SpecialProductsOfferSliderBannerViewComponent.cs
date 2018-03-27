using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Models.ProductViewModels;

namespace TemplateDotNetCore.Controllers.Components
{
    public class SpecialProductsOfferSliderBannerViewComponent : ViewComponent
    {
        private IProductService _productService;

        public SpecialProductsOfferSliderBannerViewComponent(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var details = new DetailViewModel();
            details.ProductList = _productService.GetHotProducts(8);
            return View(details);
        }
    }
}
