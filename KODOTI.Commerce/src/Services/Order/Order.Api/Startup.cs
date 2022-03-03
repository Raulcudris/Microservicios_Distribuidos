using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order.Persistence.Database;
using Order.Service.Quieries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HealthChecks.UI.Client;

namespace Order.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(opts =>
             opts.UseSqlServer(
                 Configuration.GetConnectionString("DefaulConnection"),
                 x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Order")
                 )
             );
            services.AddHealthChecks()
           .AddCheck("Actualizaciones..", () => HealthCheckResult.Healthy())
           .AddDbContextCheck<ApplicationDbContext>();
            services.AddHealthChecksUI();
            services.AddTransient<IOrderQueryService, OrderQueryService>();
            services.AddMediatR(Assembly.Load("Customer.Service.EventHandlers"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
