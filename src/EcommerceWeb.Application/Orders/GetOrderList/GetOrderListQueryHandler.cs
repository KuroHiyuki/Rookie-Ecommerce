using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.Common.Response;
using EcommerceWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderModelAppLayer>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderModelAppLayer>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrdersListAsync();
            var orderDetail = order.Select(c => new OrderModelAppLayer
            {
                UserName = c.UserName,
                Address = c.Address,
                NumberPhone = c.TelephoneNumber,
                method = c.PaymentMethod,
                status = c.Status,
                TotalAmount = c.TotalAmount,
                Note = c.Note,
                products = c.Details.Select(x => new ProductOrder
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product!.Name,
                    UnitPrice = x.UnitPrice,
                    Quantity = x.Quantity,
                    ImageURL = x.Product.ImageURL
                }).ToList()
            }).ToList();

            return orderDetail;
        }
    }
}
