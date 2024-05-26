using MediatR;

namespace EcommerceWeb.Application.Carts.AddProduct
{
    public record AddProductToCartCommand(string ProductId, int Quantity, string UserId) : IRequest
    {
    }
}
