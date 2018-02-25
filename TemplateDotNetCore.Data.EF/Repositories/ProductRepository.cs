using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int> , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
