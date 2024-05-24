using EcommerceWeb.Application.Categories.Common.Response;
using EcommerceWeb.Application.Categories.CreateCategory;
using EcommerceWeb.Application.Categories.DeleteCategory;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Products.DeleteProduct;
using EcommerceWeb.Presentation.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{
    [Route("[controller]")]
    public class CategoryController : APIController
    {
        private readonly MediatR.ISender _mediator;
        public CategoryController(MediatR.ISender mediator)
        {
            _mediator = mediator;
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
                var command = new CreateCategoryCommand(model.Name!,model.Description!);
                await _mediator.Send(command);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
