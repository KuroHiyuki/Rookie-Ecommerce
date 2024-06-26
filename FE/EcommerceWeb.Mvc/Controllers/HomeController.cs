using EcommerceWeb.Mvc.Models;
using EcommerceWeb.Mvc.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceWeb.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			if (TempData.ContainsKey("ErrorMessage"))
			{
				ViewBag.ErrorMessage = TempData["ErrorMessage"];
			}

            int count = int.Parse(Request.Cookies["Count-cart"] ?? "0");

            Response.Cookies.Append("Count-cart", (count).ToString());

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
