using System.Collections.Generic;
using TemplateDotNetCore.Data.Entities;
using TemplateDotNetCore.Infrastucture.Interfaces;

namespace TemplateDotNetCore.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory,int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}