using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateDotNetCore.Application.ViewModels;

namespace TemplateDotNetCore.Models
{
    public class ShoppingCartViewModel
    {
        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ColorViewModel Color { get; set; }
    }
}
