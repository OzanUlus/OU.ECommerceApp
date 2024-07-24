using ECommerce.Order.Application.Features.CQRS.Queries.AdressQueries;
using ECommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using ECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using ECommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailQuery  getOrderDetailQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDetailQuery.Id);
            return new GetOrderDetailByIdQueryResult
            {
               OrderDetailId = values.OrderDetailId,
               OrderingId = values.OrderingId,
               ProductAmount = values.ProductAmount,
               ProductId = values.ProductId,
               ProductName = values.ProductName,
               ProductPrice = values.ProductPrice,
               ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
