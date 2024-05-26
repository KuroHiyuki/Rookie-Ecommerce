using MediatR;

namespace EcommerceWeb.Application.Carts.AddProduct
{
    public record AddProductToCartCommand(string Id) : IRequest
    {
    }
}
