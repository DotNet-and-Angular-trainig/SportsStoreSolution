using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsStoreApp.Models.Abstract;
using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Models.Concrete
{
  public class EFOrderRepository : IOrderRepository
  {
    private readonly SportsStoreDbContext _context;

    public EFOrderRepository(SportsStoreDbContext sportsStoreDbContext)
    {
      _context = sportsStoreDbContext;
    }
    public async Task<Order> GetOrderByIdAsync(int orderId) => await _context.Orders.FindAsync(orderId);

    public async Task<IEnumerable<Order>> GetOrdersAsync() => await _context.Orders.ToListAsync();

    public async Task<bool> RemoveOrderAsync(int orderId)
    {
      var order = await _context.Orders.FindAsync(orderId);
      _context.Orders.Remove(order);
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Order> SaveOrderAsync(Order order)
    {
      if (order.OrderId == 0)
      {
        _context.Orders.Add(order);
      }
      else
      {
        _context.Entry<Order>(order).State = EntityState.Modified;
      }
      if (await _context.SaveChangesAsync() > 0)
      {
        return order;
      }
      return null;
    }
  }
}
