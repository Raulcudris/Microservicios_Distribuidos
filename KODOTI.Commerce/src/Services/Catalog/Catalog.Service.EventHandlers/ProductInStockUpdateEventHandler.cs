using Catalog.Domain;
using Catalog.Persistence.Database;

using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateEventHandler : INotificationHandler<ProductInStockUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateEventHandler> _logger;

        public ProductInStockUpdateEventHandler(
            ApplicationDbContext context,
            ILogger<ProductInStockUpdateEventHandler>logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateCommand notification,CancellationToken cancellationToken)
        {
            _logger.LogInformation(" --- ProductInStockUpdateCommand Started");
            var products = notification.Items.Select(x =>x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation(" --- Retrieve products from database");

            foreach (var item in notification.Items) 
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (item.Action == ProductInStockAction.Substract) 
                {
                    if (entry == null || item.Stock > entry.Stock ) 
                    {
                        _logger.LogError($"Product{entry.ProductId} -doens't have enough stock");
                      
                        throw new ProductInStockUpdateCommandException  ($"Product{entry.ProductId} -doens't have enough stock");
                    }

                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"Product{entry.ProductId} -its stock was Subtracted -- new stock {entry.Stock}");

                }
                else 
                {
                    if (entry == null) 
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };
                        await _context.AddAsync(entry);

                        _logger.LogInformation($"-- new stock record was created for {entry.ProductId} because didn't exist before ");
                    }
                    entry.Stock += item.Stock;
                    _logger.LogInformation($"Product{entry.ProductId} -its stock was increased and its new stock is {entry.Stock}");
                }
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation(" --- ProductInStockUpdateCommand Ended");
        }
      
    }
}
