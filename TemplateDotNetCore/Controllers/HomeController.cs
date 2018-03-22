using System;
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
        public IActionResult Index()
        {
            ViewData["BodyClass"] = "cms-index-index cms-home-page";
            return View();
        }

        [Route("thong-tin-ve-cong-ty.html")]
        public IActionResult About()
        {
            return View();
        }

        [Route("lien-he.html")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
