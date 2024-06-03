using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
