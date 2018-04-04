using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Application.ViewModels.Common;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        IQueryable<ProductViewModel> GetAll();

        ProductViewModel GetById(int id);

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        //void Update(ProductViewModel productVm);

        List<ProductImageViewModel> GetImages(int productId);

        List<ProductViewModel> GetHotProducts(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<TagViewModel> GetProductTags(int productId);

        void Delete(int id);

        ProductViewModel Add(ProductViewModel productViewModel);

        void Save();

    }
}
