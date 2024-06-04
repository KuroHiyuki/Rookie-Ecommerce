using Azure.Core;
using EcommerceWeb.Application.Reviews.CreateReview;
using EcommerceWeb.Application.Reviews.DeleteReview;
using EcommerceWeb.Application.Reviews.GetReviewList;
using EcommerceWeb.Application.Reviews.GetReviewListByProduct;
using EcommerceWeb.Application.Reviews.UpdateReview;
using EcommerceWeb.Domain.Entities;
using EcommerceWeb.Presentation.Reviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpDelete("{ReviewId},{UserId}")]
        public async Task<IActionResult> DeleteReviewProductAsync(string ReviewId, string UserId)
        {
            try
            {
                var command = new DeleteReviewCommand(UserId,ReviewId);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewList()
        {
            try
            {
                var query = new GetReivewListQuery();

                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
				return BadRequest(ex.Message);
			}
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetReviewList(string ProductId)
        {
            try
            {
                var query = new GetReviewListByProductQuery(ProductId);

                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {
				return BadRequest(ex.Message);
			}
        }
        [HttpPut("{ReviewId},{UserId}")]
        public async Task<IActionResult> UpdateReviewAsync(string ReviewId, string UserId, ReviewRequest request)
        {
            try
            {
                var command = new UpdateReviewCommand(UserId,ReviewId, request.Comment!,request.Rating);
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
