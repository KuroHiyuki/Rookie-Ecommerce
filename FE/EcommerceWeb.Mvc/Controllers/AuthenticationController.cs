using EcommerceWeb.Mvc.Models.Authentication;
using EcommerceWeb.Mvc.Services.Authenticaions;
using EcommerceWeb.Presentation.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
	public class AuthenticationController : Controller
	{
		private readonly IAuthenticationServices _authenticationService;

		public AuthenticationController(IAuthenticationServices authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                await _authenticationService.RegisterAsync(request);
                return RedirectToAction("Index", "Authentication");
            }
            return View("Error");
        }
    }
}
