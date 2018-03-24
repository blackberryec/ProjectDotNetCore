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
    public class SlideShowViewComponent : ViewComponent
    {
        private ISlideService _slideService;
        private IMemoryCache _memoryCache;

        public SlideShowViewComponent(ISlideService slideService, IMemoryCache memoryCache)
        {
            _slideService = slideService;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slides = _memoryCache.GetOrCreate(CacheKeys.Slides, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromHours(2);
                return _slideService.GetAll();
            });
            return View(slides);
        }
    }
}
