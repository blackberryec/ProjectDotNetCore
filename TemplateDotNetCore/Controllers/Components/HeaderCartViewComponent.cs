﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemplateDotNetCore.Models;
using TemplateDotNetCore.Utilities.Constants;

namespace TemplateDotNetCore.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext.Session.GetString(CommonConstants.CartSession);
            var cart = new List<ShoppingCartViewModel>();
            if (session != null)
            {
                cart = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(session);
            }
            return View(cart);
        }
    }
}