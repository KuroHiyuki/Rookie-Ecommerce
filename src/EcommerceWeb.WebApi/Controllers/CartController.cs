using EcommerceWeb.Application.Carts.AddProduct;
using EcommerceWeb.Presentation.Carts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    public class CartController : APIController
    {
        private readonly ISender _mediator;

        public CartController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddProductToCart(CartRequest request)
        {
            try
            {
                var command = new AddProductToCartCommand(request.ProductId!,request.Quantity,request.UserId!);
                await _mediator.Send(command);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
