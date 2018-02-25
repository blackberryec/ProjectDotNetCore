using System;
using System.Collections.Generic;
using System.Text;
using TemplateDotNetCore.Application.ViewModels;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
