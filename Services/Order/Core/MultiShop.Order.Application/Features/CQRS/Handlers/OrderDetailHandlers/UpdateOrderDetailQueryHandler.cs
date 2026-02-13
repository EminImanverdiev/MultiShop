using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand request)
        {
            var detail = await _repository.GetByIdAsync(request.Id);
            if (detail == null)
            {
                throw new Exception("OrderDetail not found");
            }
            detail.ProductAmount = request.ProductAmount;
            detail.ProductId = request.ProductId;
            detail.ProductName = request.ProductName;
            detail.ProductPrice = request.ProductPrice;
            detail.TotalPrice = request.TotalPrice;
            detail.OrderingId = request.OrderingId;
            await _repository.UpdateAsync(detail);
        }
    }
}
