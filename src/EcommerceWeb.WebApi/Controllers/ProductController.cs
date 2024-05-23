using Azure.Core;
using EcommerceWeb.Application.Common.Errors;
using EcommerceWeb.Application.Products.CreateProduct;
using EcommerceWeb.Application.Products.DeleteProduct;
using EcommerceWeb.Application.Products.GetById;
using EcommerceWeb.Application.Products.UpdateProduct;
using EcommerceWeb.Presentation.Products;
using ErrorOr;
using FluentEmail.Core.Interfaces;
using MapsterMapper;
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
        private readonly IMapper _mapper;
        private readonly MediatR.ISender _mediator;
        public ProductController(IMapper mapper, MediatR.ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductRequest product)
        {
            try
            {
                var command = _mapper.Map<CreateProductCommand>(product);
                await _mediator.Send(command);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:string}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand(new string(id)));

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById(string id, [FromForm] UpdateProductRequest request)
        {
            try
            {
                var command = _mapper.Map<UpdateProductCommand>(request);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
        [AllowAnonymous]
        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var query = new GetProductByIdQuery(new string(id));

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IActionResult> GetProducts(
        //    string? searchTerm,
        //string? sortOrder,
        //    string? sortColumn,
        //    int page = 1,
        //    int pageSize = 10)
        //{
        //    var query = new GetListProductQuery(searchTerm, sortOrder, sortColumn, page, pageSize);

        //    var result = await _sender.Send(query);

        //    return Ok(result.Value);
        //}

        //[AllowAnonymous]
        //[HttpGet("collections/{categoryName}")]
        //public async Task<IActionResult> GetProductsByCategoryId(string categoryName)
        //{
        //    var query = new GetProductsByCategoryNameQuery { CategoryName = categoryName };

        //    var result = await _sender.Send(query);
        //    return Ok(result.Value);
        //}





        //[HttpPatch("{id}/status")]
        //public async Task<IActionResult> UpdateProductStatus(int id, [FromQuery] ProductStatus status)
        //{
        //    var command = new UpdateProductStatusCommand { Id = id, Status = status };

        //    await _sender.Send(command);

        //    return Ok("Update product status successfully!");
        //}


    }
}
