using EcommerceWeb.Application.Users.DeleteUser;
using EcommerceWeb.Application.Users.GetList;
using EcommerceWeb.Domain.Entities;
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
        [HttpGet] 
        public async Task<IActionResult> GetUserListAsync()
        {
            try
            {
                var query = new GetUserListQuery();
                
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
