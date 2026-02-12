using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand request)
        {
            var address = await _repository.GetByIdAsync(request.Id);
            if (address == null)
            {
                throw new Exception("Address not found");
            }
            address.UserId = request.UserId;
            address.District = request.District;
            address.City = request.City;
            address.Detail = request.Detail;
            await _repository.UpdateAsync(address);
        }   
    }
}
