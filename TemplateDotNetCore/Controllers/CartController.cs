﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Models;
using TemplateDotNetCore.Utilities.Constants;
using TemplateDotNetCore.Extensions;

namespace TemplateDotNetCore.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("gio-hang.html")]
        public IActionResult Index()
        {
            return View();
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
                        Color = _
                    });
                }
            }

            return new OkObjectResult(productId); 
        }

        #endregion
    }
}