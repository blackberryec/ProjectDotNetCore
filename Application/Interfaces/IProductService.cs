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
    }
}
