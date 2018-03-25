using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        IQueryable<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        //void Update(ProductViewModel productVm);

        List<ProductImageViewModel> GetImages(int productId);

        List<ProductViewModel> GetHotProducts(int top);

        void Delete(int id);

        ProductViewModel Add(ProductViewModel productViewModel);

        void Save();

    }
}
