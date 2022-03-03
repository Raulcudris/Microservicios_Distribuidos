using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Persistence.Database.Configuration;
using System;

namespace Order.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options
       )
       : base(options)
        {

        }

        public DbSet<order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Database schema
            builder.HasDefaultSchema("Order");
            //builder.HasDefaultSchema("Customer");
            ModelConfig(builder);
            // ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new OrderConfiguration(modelBuilder.Entity<order>());

        }
    }
}
