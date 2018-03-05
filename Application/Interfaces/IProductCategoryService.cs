using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TemplateDotNetCore.Application.ViewModels;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IProductCategoryService
    {
        void Add(ProductCategoryViewModel productCategoryVm);

        void Update(ProductCategoryViewModel productCategoryVm);

        void Remove(ProductCategoryViewModel productCategoryVm);

        void Remove(int id);

        List<ProductCategoryViewModel> GetAll();

        void Save();
    }
}