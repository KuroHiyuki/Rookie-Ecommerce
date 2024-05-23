using EcommerceWeb.Application.Products.Common.Response;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace EcommerceWeb.Application.Products.CreateProduct
{
    public record CreateProductCommand(
        ProductModelAppLayer product): IRequest;
}
