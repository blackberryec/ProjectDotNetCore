using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Infrastucture.Enums;

namespace TemplateDotNetCore.Controllers.Components
{
    public class NavigationCategoriesBarViewComponent : ViewComponent
    {
        private IProductCategoryService _productCategoryService;
        private IMemoryCache _memoryCache;
        public NavigationCategoriesBarViewComponent(IProductCategoryService productCategoryService, IMemoryCache memoryCache)
        {
            _productCategoryService = productCategoryService;
            _memoryCache = memoryCache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _memoryCache.GetOrCreate(CacheKeys.ProductCategories, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(2);
                return _productCategoryService.GetAll();
            });

            return View(categories);
        }
    }
}
