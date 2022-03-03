using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Persistence.Database.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<order> entityTypeBuilder)
        {
            //entityTypeBuilder.Property(x => x.).IsRequired().HasMaxLength(100);

            //order by default

            var orders = new List<order>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                orders.Add( new order
                {
                    OrderId = i,
                    ClientId =i,
                    CreatedAt = DateTime.Now,
                    Total = random.Next(100, 1000),
                }
               );

            }
            entityTypeBuilder.HasData(orders);
        }
    }
}
