using EcommerceWeb.Application.Users.DeleteUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : APIController
    {
        private readonly ISender _mediator;

        public UserController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUserAsync(string UserId)
        {
            try
            {
                var command = new DeleteUserCommand(UserId);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
