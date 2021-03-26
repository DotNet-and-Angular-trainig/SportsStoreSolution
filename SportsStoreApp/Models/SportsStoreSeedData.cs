using SportsStoreApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreApp.Models
{
  public static class SportsStoreSeedData
  {
    public static void PopulateSportsStore(SportsStoreDbContext context)
    {
      if (!context.Products.Any())
      {
        context.Products.AddRange(
                    new Product { ProductName="Kayak", Description="A boat for one person", Price=275.00m, Category="Watersports"},
                    new Product { ProductName="Unsteady Chair", Description="Secretly give your opponent a disadvantage", Price=29.95m, Category="Chess"},
                    new Product { ProductName="Lifejacket", Description="Protective and fashionable", Price=48.95m, Category="Watersports"},
                    new Product { ProductName="Soccer ball", Description="FIFA-approved size and weight", Price=19.50m, Category="Soccer"},
                    new Product { ProductName="Spalding Ball", Description="NBA official Basketball", Price=160.00m, Category="Basketball"},
                    new Product { ProductName="Corner flags", Description="Give your playing field that professional touch", Price=34.95m, Category="Soccer"},
                    new Product { ProductName="Stadium", Description="Flat-packed 35,000-seat stadium", Price=79500.00m, Category="Soccer"},
                    new Product { ProductName="Thinking cap", Description="Improve your brain efficiency by 75%", Price=16.00m, Category="Chess"},
                    new Product { ProductName="Ring Net", Description="NBA size ring nets", Price=60.00m, Category="Basketball"},
                    new Product { ProductName="Human Chess", Description="A fun game for the whole family", Price=75.00m, Category="Chess"},
                    new Product { ProductName="Bling-bling King", Description="Gold-plated, diamond-studded King", Price=1200.00m, Category="Chess"},
                    new Product { ProductName="Dark Night", Description="Titanium-plated Knight", Price=800.00m, Category="Chess"},
                    new Product { ProductName="Shoe", Description="Studded shoes", Price=950.00m, Category="Soccer"},
                    new Product { ProductName="Basketball Boards", Description="Full size NBA size Boards", Price=2160.00m, Category="Basketball"},
                    new Product { ProductName="Jersey", Description="Air Jersey", Price=1200.00m, Category="Soccer"},
                    new Product { ProductName="Scooter", Description="A water bike for one or two people", Price=4275.00m, Category="Watersports"},
                    new Product { ProductName="Fox 40 whistle", Description="NBA Referres Whistel", Price=160.00m, Category="Basketball"},
                    new Product { ProductName="Surfboard", Description="Surfboard for surfing on water", Price=495.00m, Category="Watersports"});
      }

      context.SaveChanges();

      List<Order> orders = new List<Order>
      {
        new Order { Name = "Bruce Wayne", City = "Mumbai", Country = "India", Giftwrap = "false", State = "Maharashtra", Zip = "400019", Shipped = "false" },
        new Order { Name = "Peter Parker", City = "Pune", Country = "India", Giftwrap = "true", State = "Maharashtra", Zip = "500019", Shipped = "false" }
      };
      context.Orders.AddRange(orders);
      if (context.SaveChanges() > 0)
      {
        var addOrderedProducts = context.Products.Where(p => p.Category == "Watersports" || p.Category == "Chess").OrderBy(p=>p.Category).ToList();

        foreach (var order in orders)
        {
          var orderId = order.OrderId;
          var orderDetails = new List<OrderDetail>();

          int ctr = 1;
          foreach (var item in addOrderedProducts)
          {
            if (orderId == 1 && item.Category == "Watersports")
            {
              orderDetails.Add(new OrderDetail { OrderId = orderId, ProductId = item.ProductId, Count = ctr++, ProductName = item.ProductName, Price = item.Price });
            }
            else if (orderId == 2 && item.Category == "Chess")
            {
              orderDetails.Add(new OrderDetail { OrderId = orderId, ProductId = item.ProductId, Count = ctr++, ProductName = item.ProductName, Price = item.Price });
            }
            if (ctr == 4) ctr = 1;
          }
          context.OrderDetails.AddRange(orderDetails);
        }
        context.SaveChanges();
      }
    }
  }
}
