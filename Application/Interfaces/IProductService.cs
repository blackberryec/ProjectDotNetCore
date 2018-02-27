using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Utilities.Dtos;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        IEnumerable<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
    }
}
