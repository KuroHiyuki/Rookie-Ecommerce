using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
