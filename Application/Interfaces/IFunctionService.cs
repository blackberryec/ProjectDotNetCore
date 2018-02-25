using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateDotNetCore.Application.ViewModels;

namespace TemplateDotNetCore.Application.Interfaces
{
    public interface IFunctionService : IDisposable
    {
        Task<List<FunctionViewModel>> GetAll();
        List<FunctionViewModel> GetAllByPermission(Guid userId);
    }
}
