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

        public SlideShowViewComponent(ISlideService slideService)
        {
            _slideService = slideService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slides = _slideService.GetAll();
            return View(slides);
        }
    }
}
