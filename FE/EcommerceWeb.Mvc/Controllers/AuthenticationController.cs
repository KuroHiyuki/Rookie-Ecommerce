using EcommerceWeb.Mvc.Extensions;
using EcommerceWeb.Mvc.Models.Authentication;
using EcommerceWeb.Mvc.Models.Common;
using EcommerceWeb.Mvc.Models.Products;
using EcommerceWeb.Mvc.Services.Authenticaions;
using EcommerceWeb.Presentation.Reviews;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public IActionResult Logout()
        {
			foreach (var cookie in Request.Cookies.Keys)
			{
				Response.Cookies.Delete(cookie);
			}
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Index()
		{
            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }

            return View();
        }
        [HttpPost("Login")] 
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                if (!ValidationService.IsValidEmail(request.Email!))
                {
                    TempData["ErrorMessage"] = "Email address is invalid.";
                    return RedirectToAction("Index", "Authentication");
                }
                var response = await _authenticationService.LoginAsync(request);
                if (!response.IsSuccessStatusCode)
                {
					TempData["ErrorMessage"] = await Extension.ErrorRespone(response);
					return RedirectToAction("Index", "Authentication");
                }
                else
                {
                    var Content = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<AuthenticationVM>(Content)!;
                    CookieSetting(user);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Error");
        }

        

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request,string confirmedPassword)
        {
            if (ModelState.IsValid)
            {
                if(ValidateRequest(request, confirmedPassword))
                {
                    return RedirectToAction("Index", "Authentication");
                }
                var response = await _authenticationService.RegisterAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    TempData["ErrorMessage"] = await Extension.ErrorRespone(response);
                    return RedirectToAction("Index", "Authentication");
                }
                TempData["ErrorMessage"] = "Registered success!";
                return RedirectToAction("Index", "Authentication");
            }
            return View("Error");
           
        }

        private bool ValidateRequest(RegisterRequest request = default!, string confirmedPassword = default!)
        {
            if (!ValidationService.IsValidEmail(request.Email!))
            {
                TempData["ErrorMessage"] = "Email address is invalid.";
                return true;
            }
            if (!ValidationService.IsValidPassword(request.Password!))
            {
                TempData["ErrorMessage"] = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";
                return true;
            }

            if (request.Password != confirmedPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match.";
                return true;
            }
            if (!ValidationService.IsValidPhoneNumber(request.NumberPhone!))
            {
                TempData["ErrorMessage"] = "Phone number is invalid. Please enter a valid Vietnamese phone number (starting with 0 and followed by 9 digits).";
                return true;
            }
            return false;
        }
        

        private void CookieSetting(dynamic user)
        {
            Response.Cookies.Append("JWToken", user.Token, new CookieOptions { HttpOnly = true, Secure = true });
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("UserId", user.Id, options);
            Response.Cookies.Append("Username", user.FirstName, options);
        }
    }
}
