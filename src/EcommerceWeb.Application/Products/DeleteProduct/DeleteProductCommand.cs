using ErrorOr;
using MediatR;


namespace EcommerceWeb.Application.Products.DeleteProduct
{
    public record DeleteProductCommand(string Id) : IRequest;
}
