using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(o=> new GetOrderDetailQueryResult
            {
                Id = o.Id,
                OrderingId = o.OrderingId,
                ProductId = o.ProductId,
                ProductPrice = o.ProductPrice,
                ProductAmount = o.ProductAmount,
                ProductName = o.ProductName,
                TotalPrice = o.TotalPrice
            }).ToList();
        }
    }
}