using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
