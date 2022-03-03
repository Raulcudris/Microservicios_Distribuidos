using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder) 
        {
            entityBuilder.HasKey(x=> x.ProductInStockId);

            var products = new List<ProductInStock>();
            var random = new Random();
            //Stock
            for (var i = 1; i <= 100; i++)
            {
                products.Add(new ProductInStock           
                  {
                        ProductInStockId = i,
                        ProductId = i,
                        Stock = random.Next(0, 20)
                    
                });
            }
            //entityTypeBuilder.HasData(products);
            entityBuilder.HasData(products);

        }
    }
}
