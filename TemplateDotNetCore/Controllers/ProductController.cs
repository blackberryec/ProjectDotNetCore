using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Models.ProductViewModels;

namespace TemplateDotNetCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IBillService _billService;


        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IBillService billService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _billService = billService;
        }

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

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            ViewData["BodyClass"] = "product-page";
            var model = new DetailViewModel();
            model.Product = _productService.GetById(id);
            model.Category = _productCategoryService.GetById(model.Product.CategoryId);
            model.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            model.ProductImages = _productService.GetImages(id);
            model.Tags = _productService.GetProductTags(id);
            model.Colors = _billService.GetColors().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return View(model);
        }

        [Route("so-sanh-san-pham.html")]
        public IActionResult Compare()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}