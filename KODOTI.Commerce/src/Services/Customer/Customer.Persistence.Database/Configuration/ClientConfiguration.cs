﻿using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Persistence.Database.Configuration
{
    public class ClientConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Client> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //Clients by default

            var clients = new List<Client>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                clients.Add(new Client
                {
                    ClientId = i,
                    Name = $"Client{i}",                

                });

            }
            entityTypeBuilder.HasData(clients);
        }
    }
}
