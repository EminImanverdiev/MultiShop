namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public DeleteAddressCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
