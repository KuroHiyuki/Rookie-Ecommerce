using Azure.Core;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.CreateProduct;
using EcommerceWeb.Application.Products.DeleteProduct;
using EcommerceWeb.Application.Products.GetbyCategory;
using EcommerceWeb.Application.Products.GetById;
using EcommerceWeb.Application.Products.GetByName;
using EcommerceWeb.Application.Products.GetListProducts;
using EcommerceWeb.Application.Products.UpdateProduct;
using EcommerceWeb.Presentation.Products;
using ErrorOr;
using FluentEmail.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.WebApi.Controllers
{

    [Route("[controller]")]
    public class ProductController : APIController
    {
        private readonly MediatR.ISender _mediator;
        public ProductController( MediatR.ISender mediator)
        {
            _mediator = mediator;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PageQuery? pageQuery)
        {
            try
            {
                var query = new GetListProductQuery(pageQuery!);

                return Ok(await _mediator.Send(query));
            }
            catch (NotFoundException e)
            {
                return Problem(e.Message);
            }
            
        }
        [AllowAnonymous]
        [HttpGet("collections/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategoryName(string categoryName, [FromQuery] PageQuery pageQuery)
        {
            try
            {
                var query = new GetProductByCategoryQuery(categoryName,pageQuery);
                return Ok(await _mediator.Send(query));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var query = new GetProductByIdQuery(id);

                return Ok(await _mediator.Send(query));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductRequest product)
        {
            try
            {
                var command = new CreateProductCommand
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Stock = product.Stock,
                    Images = product.Images,
                };
                await _mediator.Send(command);
                return Created();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand(id));

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById(string id, [FromForm] ProductRequest request)
        {
            try
            {
                var command = new UpdateProductCommand( id, request.Name, request.Description, request.Price, request.Stock, request.CategoryId, request.Images );

                await _mediator.Send(command);

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
