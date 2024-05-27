using EcommerceWeb.Application.Common.Interface;
using EcommerceWeb.Application.Orders.Common.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Orders.CreateOrderFromCart
{
    public class CreateOrderFromCartCommandHandler : IRequestHandler<CreateOrderFromCartCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderFromCartCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOrderFromCartCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.CreateOrderFromCartAsync(request.UserId);
            order.DeliveryTime = DateTime.UtcNow.AddDays(3);
            order.DeliveryPrice = 10;
            order.PaymentMethod = Domain.Common.Enum.PaymentMethod.COD;
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
