using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TemplateDotNetCore.Controllers.Components
{
    public class HeaderCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}