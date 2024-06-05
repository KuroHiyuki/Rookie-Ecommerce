using EcommerceWeb.Application.Carts.AddProduct;
using EcommerceWeb.Application.Carts.GetCartIdByUser;
using EcommerceWeb.Application.Carts.GetProductInCart;
using EcommerceWeb.Application.Carts.RemoveProductInCart;
using EcommerceWeb.Application.Carts.UpdateProductQuantity;
using EcommerceWeb.Application.Products.GetbyCategory;
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
        public async Task<IActionResult> AddProductToCart(CartModel request)
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
        [HttpPut("{CartId}")]
        public async Task<IActionResult> UpdateProductQuantityAsync(string CartId,CartRequest request)
        {
            try
            {
                var command = new UpdateProductCartQuantityCommand(CartId,request.ProductId!,request.Quantity);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
        }
        [HttpGet("{CartId},{userId}")]
        public async Task<IActionResult> GetProductListCartAsync(string CartId, string userId)
        {
            try
            {
                var query = new GetProductCartByUserIdQuery(CartId, userId);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{CartId},{ProductId}")]
        public async Task<IActionResult> DeleteProductFromCartAsync(string CartId, string ProductId)
        {
            try
            {
                var command = new RemoveProductInCartCommand(ProductId, CartId);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("getID/{UserId}")]
        public async Task<IActionResult> GetCartIdAsync(string UserId)
        {
            try
            {
                var query = new GetCartIdByUserIdQuery(UserId);
                return Ok(await _mediator.Send(query));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
