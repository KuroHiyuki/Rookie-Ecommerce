using EcommerceWeb.Mvc.Models.Authentication;
using EcommerceWeb.Mvc.Models.Common;
using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Mvc.Services.Authenticaions;
using EcommerceWeb.Presentation.Reviews;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EcommerceWeb.Mvc.Services.Authenticaions;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            // Các logic khác ở đây

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request,string confirmedPassword)
        {
            if (ModelState.IsValid)
            {
                if (!ValidationService.IsValidEmail(request.Email!))
                {
                    TempData["ErrorMessage"] = "Email address is invalid.";
                    return RedirectToAction("Index", "Authentication");
                }
                if (!ValidationService.IsValidPassword(request.Password!))
                {
                    TempData["ErrorMessage"] = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";
                    return RedirectToAction("Index", "Authentication");
                }

                // Password confirmation validation
                if (request.Password != confirmedPassword)
                {
                    TempData["ErrorMessage"] = "Passwords do not match.";
                    return RedirectToAction("Index", "Authentication");
                }
                // Phone number validation (assuming Vietnamese format)
                if (!ValidationService.IsValidPhoneNumber(request.NumberPhone!))
                {
                    TempData["ErrorMessage"] = "Phone number is invalid. Please enter a valid Vietnamese phone number (starting with 0 and followed by 9 digits).";
                    return RedirectToAction("Index", "Authentication");
                }
                var response = await _authenticationService.RegisterAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var Content = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponse>(Content)!;
                    TempData["ErrorMessage"] = error.title;
                    return RedirectToAction("Index", "Authentication");
                }
                return RedirectToAction("Index", "Authentication");
            }
            return View("Error");
           
        }

    }
}
