﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDotNetCore.Controllers
{
    public class AjaxContentController : Controller
    {
        [HttpGet]
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
    }
}