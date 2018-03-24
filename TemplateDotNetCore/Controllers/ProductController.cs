using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDotNetCore.Controllers
{
    public class ProductController : Controller
    {
        [Route("danh-muc-tat-ca-san-pham.html")]
        public IActionResult Category()
        {
            ViewData["BodyClass"] = "shop_grid_page";
            return View();
        }

        [Route("tim-kiem.html")]
        public IActionResult Search()
        {
            ViewData["BodyClass"] = "shop_grid_full_width_page";
            
            return View();
        }

        [Route("chi-tiet-san-pham.html")]
        public IActionResult Details()
        {
            ViewData["BodyClass"] = "product-page";
            return View();
        }

        [Route("so-sanh-san-pham.html")]
        public IActionResult Compare()
        {
            return View();
        }

        [Route("gio-hang.html")]
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}