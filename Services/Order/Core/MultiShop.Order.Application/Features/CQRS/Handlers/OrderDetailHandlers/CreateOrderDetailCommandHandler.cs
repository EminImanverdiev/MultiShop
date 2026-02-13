using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            var orderDetail = new OrderDetail
            {
                OrderingId = command.OrderingId,
                ProductId = command.ProductId,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProductName = command.ProductName,
                TotalPrice = command.TotalPrice
            };
            await _repository.AddAsync(orderDetail);
        }   
    }
}
