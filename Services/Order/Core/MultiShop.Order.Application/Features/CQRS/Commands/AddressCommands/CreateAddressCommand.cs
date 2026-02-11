using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
    public class DeleteAddressCommand
    {
        public DeleteAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
