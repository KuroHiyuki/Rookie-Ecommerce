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
		[HttpPost]
		public async Task<IActionResult> AddtoCart(CartRequest request)
		{
			string userId = Request.Cookies["UserId"]!;

			string refererUrl = Request.Headers["Referer"].ToString();

            int count = int.Parse(Request.Cookies["Count-cart"]);

			if (string.IsNullOrEmpty(userId))
			{
				TempData["ErrorMessage"] = "Please login before adding product to cart";

                request = null;

				return Redirect(refererUrl);
			}

			request.UserId = userId;

			await _cartServices.AddToCartAsync(request);

            Response.Cookies.Append("Count-cart", (count + 1).ToString());

            if (!string.IsNullOrEmpty(refererUrl))
			{
				return Redirect(refererUrl);
			}
			return RedirectToAction("Index", "Home");
		}
		[HttpPost("UpdateCart")]
		public async Task<IActionResult> Update(List<CartRequest> request)
		{
            string userId = Request.Cookies["UserId"]!;

            string refererUrl = Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Please login before update product to cart";

                return Redirect(refererUrl);
            }
            var cartId = await _cartServices.GetCardIdAsync(userId);

            if (cartId == null)
            {
                TempData["ErrorMessage"] = "Not found CartID";

                return Redirect(refererUrl);
            }
            if (ModelState.IsValid)
            {
                foreach (var check in request)
                {
                    if (check.Quantity == 0)
                    {
                        var deleteResponse = await _cartServices.DeleteCartAsync(cartId, check.ProductId!);

                        if (!deleteResponse.IsSuccessStatusCode)
                        {
                            TempData["ErrorMessage"] = "Failed to delete item from cart";

                            return Redirect(refererUrl);
                        }
                    }
                    check.UserId = userId;

                    var updateResponse = await _cartServices.UpdateCartAsync(cartId, check);

                    if (!updateResponse.IsSuccessStatusCode)
                    {
                        TempData["ErrorMessage"] = "Failed to update cart";

                        return Redirect(refererUrl);
                    }
                }
            }
            return Redirect(refererUrl);
		}

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(CartRequest request)
        {
            string userId = Request.Cookies["UserId"]!;

            string refererUrl = Request.Headers["Referer"].ToString();

            int count = int.Parse(Request.Cookies["Count-cart"]);

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Please login before update product to cart";

                return Redirect(refererUrl);
            }
            var cartId = await _cartServices.GetCardIdAsync(userId);

            if (cartId == null)
            {
                TempData["ErrorMessage"] = "Not found CartID";

                return Redirect(refererUrl);
            }
            request.UserId = userId;

            var response = await _cartServices.DeleteCartAsync(cartId, request.ProductId!);

            if (!response.IsSuccessStatusCode)
            {
                TempData["ErrorMessage"] = "Not found CartID";

                return Redirect(refererUrl);
            }
            Response.Cookies.Append("Count-cart", (count - 1).ToString());

            return Redirect(refererUrl);
        }
    }
}
