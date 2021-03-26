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
  public class EFOrderDetailRepository : IOrderDetailRepository
  {
    private readonly SportsStoreDbContext _context;

    public EFOrderDetailRepository(SportsStoreDbContext sportsStoreDbContext)
    {
      _context = sportsStoreDbContext;
    }

    public async Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail)
    {
      _context.OrderDetails.Add(orderDetail);
      if (await _context.SaveChangesAsync() > 0)
      {
        return orderDetail;
      }
      return null;
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailAsync(int orderId) => await _context.OrderDetails.Where(o => o.OrderId == orderId).ToListAsync();

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync() => await _context.OrderDetails.ToListAsync();

    public async Task<bool> RemoveOrderDetailAsync(int orderId)
    {
      var orderDetail = await _context.OrderDetails.Where(o=> o.OrderId == orderId).ToListAsync();
      _context.OrderDetails.RemoveRange(orderDetail);
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail)
    {
      _context.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return orderDetail;
    }
  }
}
