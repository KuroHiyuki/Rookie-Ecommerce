using EcommerceWeb.Application.Orders.CreateOrderFromCart;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    public class OrderController : APIController
    {
        private readonly ISender _mediator;

        public OrderController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{UserId}")]
        public async Task<IActionResult> CreateOrderAsync(string UserId)
        {
            try
            {
                var command = new CreateOrderFromCartCommand(UserId);
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
