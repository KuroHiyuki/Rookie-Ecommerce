using EcommerceWeb.Mvc.Models.Carts;
using EcommerceWeb.Mvc.Services.Carts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Mvc.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartServices _cartServices;

		public CartController(ICartServices cartServices)
		{
			_cartServices = cartServices;
		}

		public async Task<IActionResult> Index()
		{
			string userId = Request.Cookies["UserId"]!;
			if (ModelState.IsValid)
			{
				var cartId = await _cartServices.GetCardIdAsync(userId);
				if (cartId == null)
				{
					if (TempData.ContainsKey("ErrorMessage"))
					{
						ViewBag.ErrorMessage = TempData[cartId!];
					}
				}
				var response = await _cartServices.GetProductInCartAsynce(cartId,userId);
				return View(response);
			}
			return View("Error");
		}
		[HttpPost]
		public async Task<IActionResult> AddtoCart(CartRequest request)
		{
			string userId = Request.Cookies["UserId"]!;
			string refererUrl = Request.Headers["Referer"].ToString();
			if (string.IsNullOrEmpty(userId))
			{
				TempData["ErrorMessage"] = "Please login before adding product to cart";
				if (!string.IsNullOrEmpty(refererUrl))
				{
					return Redirect(refererUrl);
				}
				return RedirectToAction("Index", "Home");
			}
			request.UserId = userId;
			await _cartServices.AddToCartAsync(request);
			if (!string.IsNullOrEmpty(refererUrl))
			{
				return Redirect(refererUrl);
			}
			return RedirectToAction("Index", "Home");
		}
	}
}
