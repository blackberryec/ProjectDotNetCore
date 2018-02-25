using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TemplateDotNetCore.Application.Interfaces;
using TemplateDotNetCore.Application.ViewModels;
using TemplateDotNetCore.Extensions;
using TemplateDotNetCore.Utilities.Constants;

namespace TemplateDotNetCore.Areas.Admin.Components
{
    public class MenuFunctionsViewComponent : ViewComponent
    {
        private IFunctionService _functionService;
        public MenuFunctionsViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                //TODO: Get by permission
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }

    }
}
