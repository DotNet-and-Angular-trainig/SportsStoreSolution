using System.Collections.Generic;
using System.Threading.Tasks;

using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Models.Abstract
{
  public interface IOrderDetailRepository
  {
    Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync();
    Task<IEnumerable<OrderDetail>> GetOrderDetailAsync(int orderId);
    Task<bool> RemoveOrderDetailAsync(int orderId);
    Task<OrderDetail> AddOrderDetailAsync(OrderDetail orderDetail);
    Task<OrderDetail> UpdateOrderDetailAsync(OrderDetail orderDetail);
  }
}
