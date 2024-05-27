using EcommerceWeb.Application.Reviews.CreateReview;
using EcommerceWeb.Presentation.Reviews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    public class ReviewController : APIController
    {
        private readonly ISender _mediator;

        public ReviewController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{UserId},{ProductId}")]
        public async Task<IActionResult> CreateReviewProductAsync(string UserId, string ProductId, [FromBody]ReviewRequest request)
        {
            try
            {
                var command = new CreateReviewCommand(UserId, ProductId, request.Rating, request.Comment!);
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
