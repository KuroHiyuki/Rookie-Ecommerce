using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace EcommerceWeb.Application.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description ,
        decimal Price ,
        int Stock ,
        string CategoryId,
        string UserId,
        IFormFileCollection? Images) : IRequest<ErrorOr<FluentResults.Result>>;
}
