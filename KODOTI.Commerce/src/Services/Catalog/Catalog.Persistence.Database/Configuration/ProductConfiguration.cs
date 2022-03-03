using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistence.Database.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x=> x.ProductId);
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            //Products by default

            var products = new List<Product>();
            var random = new Random();

            for (var i=1; i<=100; i++)
            {
                products.Add(new Product
                {
                    ProductId = i,
                    Name = $"Product{i}",
                    Description = $"Description for Product {i}",
                    Price = random.Next(100, 1000),
               
                }) ; 

            }
            entityTypeBuilder.HasData(products);
             
        }
    }
}
