using System;


namespace Catalog.Service.EventHandlers.Exceptions
{
    public class ProductInStockUpdateCommandException : Exception
    {
        public ProductInStockUpdateCommandException(string message)
            : base(message)
        {

        }
    }
}
