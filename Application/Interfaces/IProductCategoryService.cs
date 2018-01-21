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

        void RemoveMultiple(List<ProductCategoryViewModel> entities);

        ProductCategoryViewModel FindById(int id, params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties);

        ProductCategoryViewModel FindSingle(Expression<Func<ProductCategoryViewModel, bool>> predicate, params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties);

        IQueryable<ProductCategoryViewModel> FindAll(params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties);

        IQueryable<ProductCategoryViewModel> FindAll(Expression<Func<ProductCategoryViewModel, bool>> predicate,
            params Expression<Func<ProductCategoryViewModel, object>>[] includeProperties);

        IQueryable<ProductCategoryViewModel> FindMultiPaging(Expression<Func<ProductCategoryViewModel, bool>> filter, out int total, int index = 0, int size = 50,
            string[] includes = null);
    }
}