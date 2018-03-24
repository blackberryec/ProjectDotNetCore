using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDotNetCore.Controllers
{
    public class BlogController : Controller
    {
        [Route("blog-review.html")]
        public IActionResult Index()
        {
            return View();
        }
    }
}