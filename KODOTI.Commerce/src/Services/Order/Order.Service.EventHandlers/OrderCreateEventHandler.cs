using MediatR;
using Order.Service.EventHandlers.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Persistence.Database;
using Order.Domain;


namespace Order.Service.EventHandlers
{
    public class OrderCreateEventHandler : INotificationHandler<OrderCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public OrderCreateEventHandler(
          ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(OrderCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new order
            {
                Status = command.Status,
                PaymentType = command.PaymentType,
                ClientId = command.ClientId,
                Items = command.Items,
                CreatedAt = command.CreatedAt,
                Total = command.Total
            });
            await _context.SaveChangesAsync();

        }
    }
}
