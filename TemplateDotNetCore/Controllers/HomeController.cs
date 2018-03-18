﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateDotNetCore.Models;

namespace TemplateDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        [Route("trang-chu.html")]
        public IActionResult Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            return View();
        }
    }
}
