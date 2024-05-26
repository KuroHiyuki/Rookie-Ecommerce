using EcommerceWeb.Application.Carts.Common.Repositories;
using EcommerceWeb.Application.Common.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Application.Carts.UpdateProductQuantity
{
    public class UpdateProductCartQuantityCommandHandler : IRequestHandler<UpdateProductCartQuantityCommand>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCartQuantityCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCartQuantityCommand command, CancellationToken cancellationToken)
        {
            await _cartRepository.UpdateProductQuantity(command.CartId, command.ProductId, command.Quantity);
            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
