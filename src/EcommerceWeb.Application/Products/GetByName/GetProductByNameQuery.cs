using EcommerceWeb.Application.Products.Common.Response;
using ErrorOr;
using MediatR;


namespace EcommerceWeb.Application.Products.GetByName
{
    public record GetProductByNameQuery(string CategoryName) : IRequest<IEnumerable<ProductModelAppLayer>>
    {
    }
}
