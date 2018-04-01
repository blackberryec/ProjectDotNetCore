using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Models;
using TemplateDotNetCore.Utilities.Constants;
using TemplateDotNetCore.Extensions;

namespace TemplateDotNetCore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBillService _billService;

        public CartController(IProductService productService, IBillService billService)
        {
            _productService = productService;
            _billService = billService;
        }

        [Route("gio-hang.html")]
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString(CommonConstants.CartSession);
            var cart = new List<ShoppingCartViewModel>();
            if (session != null)
            {
                cart = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(session);
            }
            return View(cart);
        }

        #region API Request

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity, int color)
        {
            //Get product detail
            var product = _productService.GetById(productId);

            //Get session with item list from cart
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            {
                //Conver string to list object
                bool hasChanged = false;

                //Check exist with item product id
                if (session.Any(x => x.Product.Id == productId))
                {
                    foreach (var item in session)
                    {
                        //Update quantity for product if match product id
                        if (item.Product.Id == productId)
                        {
                            item.Quantity += quantity;
                            item.Price = product.PromotionPrice ?? product.Price;
                            hasChanged = true;
                        }
                    }
                }
                else
                {
                    session.Add(new ShoppingCartViewModel()
                    {
                        Product = product,
                        Quantity = quantity,
                        Color = _billService.GetColors(color),
                        Price = product.PromotionPrice ?? product.Price
                    });
                    hasChanged = true;
                }

                //Update back to cart 
                if (hasChanged)
                {
                    HttpContext.Session.Set(CommonConstants.CartSession, session);
                }
            }
            else
            {
                //add new cart 
                var cart = new List<ShoppingCartViewModel>();
                cart.Add(new ShoppingCartViewModel()
                {
                    Product = product,
                    Quantity = quantity,
                    Color = _billService.GetColors(color),
                    Price = product.PromotionPrice ?? product.Price
                });
                HttpContext.Session.Set(CommonConstants.CartSession, cart);
            }

            return new OkObjectResult(productId); 
        }

        public IActionResult RemoveItemOnCart(int productId)
        {
            var session = HttpContext.Session.Get<List<ShoppingCartViewModel>>(CommonConstants.CartSession);
            if (session != null)
            {
                bool hasChanged = false;
                foreach (var item in session)
                {
                    if (item.Product.Id == productId)
                    {
                        session.Remove(item);
                        hasChanged = true;
                        break;
                    }
                }
                if (hasChanged)
                {
                    HttpContext.Session.Set(CommonConstants.CartSession,session);
                }
                return new ObjectResult(productId);
            }
            return new EmptyResult();
        }

        #endregion
    }
}