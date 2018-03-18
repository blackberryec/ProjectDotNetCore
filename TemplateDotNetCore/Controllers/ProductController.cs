using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDotNetCore.Controllers
{
    public class ProductController : Controller
    {
        [Route("danh-muc-san-pham.html")]
        public IActionResult Index()
        {
            ViewData["BodyClass"] = "shop_grid_page";
            return View();
        }
    }
}