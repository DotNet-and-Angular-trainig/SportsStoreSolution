using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsStoreApp.Models.Concrete;
using SportsStoreApp.Models.Abstract;
using Microsoft.AspNetCore.Routing;

namespace SportsStoreApp
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddDbContext<SportsStoreDbContext>(cfg =>
      {
        cfg.UseSqlServer(Configuration["ConnectionStrings:SportsStoreConnection"], sqlServerOptionsAction: sqlOptions =>
        {
          sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
        cfg.UseLoggerFactory(LoggerFactory.Create(cfg => { cfg.AddConsole(); })).EnableSensitiveDataLogging();
      });

      services.AddScoped<IProductRepository, EFProductRepository>();
      services.AddScoped<IOrderRepository, EFOrderRepository>();
      services.AddScoped<IOrderDetailRepository, EFOrderDetailRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      using (var scope = app.ApplicationServices.CreateScope())
      {
        SportsStoreDbContext context = scope.ServiceProvider.GetRequiredService<SportsStoreDbContext>();// will get the SportsStoreDbContext object
        var createDatabase = context.Database.EnsureCreated();
        if (createDatabase)
        {
          SportsStoreSeedData.PopulateSportsStore(context);
          logger.LogInformation($"***SportsStoreSeedData Called, '{context.Products.Count()}' - Products Added\n'{context.Orders.Count()}' - Orders Added\n'{context.OrderDetails.Count()}' - OrderDetails Added***");
        }
      }

      app.UseRouting();

      app.UseEndpoints(ConfigureRoutes);
    }

    private void ConfigureRoutes(IEndpointRouteBuilder routerBuilder)
    {
      routerBuilder.MapControllers();
      routerBuilder.MapGet("/", async context =>
      {
        await context.Response.WriteAsync("<div style='background-color:Cornflowerblue; text-align: center; color: White;'>" +
          "<h1>Sports Store Site Under Construction</h1>" +
          "</div>");
      });
    }
  }
}
