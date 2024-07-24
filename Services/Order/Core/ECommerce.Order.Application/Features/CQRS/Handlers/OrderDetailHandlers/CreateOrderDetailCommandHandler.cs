using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task Handle(CreateOrderDetailCommand command) 
        {
            await _orderDetailRepository.CreateAsync(new OrderDetail 
            {
              OrderingId = command.OrderingId,
              ProductAmount = command.ProductAmount,
              ProductId = command.ProductId,
              ProductName = command.ProductName,
              ProductPrice = command.ProductPrice,
              ProductTotalPrice = command.ProductTotalPrice,
            });
        }
    }
}
