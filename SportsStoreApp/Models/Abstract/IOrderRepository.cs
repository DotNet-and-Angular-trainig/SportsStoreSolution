using System.Collections.Generic;
using System.Threading.Tasks;

using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Models.Abstract
{
  public interface IOrderRepository
  {
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int orderId);
    Task<bool> RemoveOrderAsync(int orderId);
    Task<Order> SaveOrderAsync(Order order);
  }
}
