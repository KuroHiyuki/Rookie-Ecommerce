using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
