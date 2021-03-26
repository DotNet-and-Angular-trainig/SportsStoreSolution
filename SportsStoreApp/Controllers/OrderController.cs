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
  [Route("api/order")]

  public class OrderController : Controller
  {
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    [HttpGet, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get()
    {
      var orders = await _orderRepository.GetOrdersAsync();
      return Ok(orders);
    }
    [HttpGet, Route("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get(int id)
    {
      var order = await _orderRepository.GetOrderByIdAsync(id);
      return Ok(order);
    }

    [HttpPost, Route("")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IActionResult> Post([FromBody] Order order)
    {
      var newOrder = await _orderRepository.SaveOrderAsync(order);
      return Ok(newOrder);
    }
    
    [HttpPut, Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IActionResult> Put([FromBody] Order order)
    {
      var updateOrder = await _orderRepository.SaveOrderAsync(order);
      return Ok(updateOrder);
    }

    [HttpDelete, Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
      var flag = await _orderRepository.RemoveOrderAsync(id);
      if (flag)
      {
        return RedirectToAction("Get");
      }
      return NotFound();
    }
  }
}
