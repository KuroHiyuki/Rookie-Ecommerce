using EcommerceWeb.Application.Orders.Common.Repository;
using EcommerceWeb.Application.Orders.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderModelAppLayer>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderListQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModelAppLayer> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
