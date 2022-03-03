using Catalog.Domain;
using Catalog.Service.EventHandlers;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using Catalog.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Catalog.Common.Enums;

namespace Catalog.Tests
{
    [TestClass]
    public class ProductInStockUpdateEventHandlerTest
    {
        private ILogger<ProductInStockUpdateEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<ProductInStockUpdateEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void TryToSubstractStockWhenProductHasStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var producInStockId = 1;
            var productId = 1;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = producInStockId,
                ProductId = productId,
                Stock = 1
            }) ;

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context,GetLogger);

            handler.Handle(new ProductInStockUpdateCommand{
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 1,
                        Action = ProductInStockAction.Substract

                    }
                }
            },new CancellationToken()).Wait();
        }
        [TestMethod]
        [ExpectedException(typeof(ProductInStockUpdateCommandException))]
        public void TryToSubstractStockWhenProductHasntStock()
        {
            var context = ApplicationDbContextInMemory.Get();

            var producInStockId = 2;
            var productId = 2;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = producInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            try
            {
                handler.Handle(new ProductInStockUpdateCommand
                {
                    Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Substract
                    }
                }
                }, new CancellationToken()).Wait();
            }
            catch (AggregateException ae)
            {
                var exception = ae.GetBaseException();
                if (exception is ProductInStockUpdateCommandException)
                {
                    throw new ProductInStockUpdateCommandException(exception?.InnerException?.Message);
                }
            }        
        }

        [TestMethod]
        public void TryToAddStockWhenProductExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var producInStockId = 3;
            var productId = 3;

            context.Stocks.Add(new ProductInStock
            {
                ProductInStockId = producInStockId,
                ProductId = productId,
                Stock = 1
            });

            context.SaveChanges();

            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add

                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;
            Assert.AreEqual(stockInDb,3);
        }
        [TestMethod]
        public void TryToAddStockWhenProductNotExists()
        {
            var context = ApplicationDbContextInMemory.Get();

            var productId = 4;
        
            var handler = new ProductInStockUpdateEventHandler(context, GetLogger);

            handler.Handle(new ProductInStockUpdateCommand
            {
                Items = new List<ProductInStockUpdateItem>()
                {
                    new ProductInStockUpdateItem
                    {
                        ProductId = productId,
                        Stock = 2,
                        Action = ProductInStockAction.Add

                    }
                }
            }, new CancellationToken()).Wait();

            var stockInDb = context.Stocks.Single(x => x.ProductId == productId).Stock;
            Assert.AreEqual(stockInDb, 2);
        }
    }
}
