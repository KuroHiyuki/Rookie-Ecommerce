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
	}
}
