using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Data.IRepositories;

namespace TemplateDotNetCore.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag,int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base (context)
        {

        }
    }
}
