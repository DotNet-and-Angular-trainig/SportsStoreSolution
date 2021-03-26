using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStoreApp.Models.Abstract;
using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Controllers
{
  [ApiController]
  [Produces("application/json")]
  [Route("api/orderdetail")]
  public class OrderDetailController: Controller
  {
    private readonly IOrderDetailRepository _orderDetailRepository;
    public OrderDetailController(IOrderDetailRepository orderDetailRepository)
    {
      _orderDetailRepository = orderDetailRepository;
    }

    [HttpGet, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderDetail>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get()
    {
      var orderDetails = await _orderDetailRepository.GetOrderDetailsAsync();
      return Ok(orderDetails);
    }

    [HttpGet, Route("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDetail))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get(int id)
    {
      var orderDetail = await _orderDetailRepository.GetOrderDetailAsync(id);
      return Ok(orderDetail);
    }

    [HttpPost, Route("")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDetail))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IActionResult> Post([FromBody] OrderDetail orderDetail)
    {
      var newOrderDetail = await _orderDetailRepository.AddOrderDetailAsync(orderDetail);
      return Ok(newOrderDetail);
    }

    [HttpPut, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDetail))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IActionResult> Put([FromBody] OrderDetail orderDetail)
    {
      var updateOrderDetail = await _orderDetailRepository.UpdateOrderDetailAsync(orderDetail);
      return Ok(updateOrderDetail);
    }

    [HttpDelete, Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int id)
    {
      var flag = await _orderDetailRepository.RemoveOrderDetailAsync(id);
      if (flag)
      {
        return RedirectToAction("Get");
      }
      return NotFound();
    }
  }
}
