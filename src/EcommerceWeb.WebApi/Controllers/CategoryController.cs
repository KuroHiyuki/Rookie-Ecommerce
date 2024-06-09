using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Categories.CreateCategory;
using EcommerceWeb.Application.Categories.DeleteCategory;
using EcommerceWeb.Application.Categories.GetAllCategory;
using EcommerceWeb.Application.Categories.GetById;
using EcommerceWeb.Application.Categories.UpdateCategory;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Products.DeleteProduct;
using EcommerceWeb.Presentation.Categories;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class CategoryController : APIController
    {
        private readonly MediatR.ISender _mediator;
        public CategoryController(MediatR.ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryIdAsync(string id)
        {
            try
            {

                return Ok(await _mediator.Send(new GetCategoryByIdQuery(id)));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            try
            {
                await _mediator.Send(new DeleteCategoryCommand(id));

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest model)
        {
            try
            {
                var command = new CreateCategoryCommand(model.Name!, model.Description!);
                await _mediator.Send(command);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategoryListAsync()
        {
            try
            {
                var categoryList = new GetCategoryListQuery();
                return Ok(await _mediator.Send(categoryList));
            }
            catch (NotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(string id,CategoryRequest model)
        {
            try
            {
                var command = new UpdateCategoryByIdCommand(id, model.Name!, model.Description!);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
