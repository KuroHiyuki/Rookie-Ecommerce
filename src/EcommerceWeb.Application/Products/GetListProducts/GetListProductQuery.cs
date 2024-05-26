using EcommerceWeb.Application.Common.Services.Paginations;
using EcommerceWeb.Application.Products.Common.Response;
using MediatR;
namespace EcommerceWeb.Application.Products.GetListProducts

{
    public record GetListProductQuery (
        PageQuery page) : IRequest<PaginatedList<ProductModelAppLayer>>
    {
    }
}
