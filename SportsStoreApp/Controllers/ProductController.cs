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
  [Route("api/product")]
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet, Route("")] //https://localhost:5001/api/product
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get()
    {
      var products = await _productRepository.GetProductsAsync();
      return Ok(products);
    }

    [HttpGet, Route("id/{id}")] //https://localhost:5000/api/product/id/22
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get(int id)
    {
      var product = await _productRepository.GetProductByIdAsync(id);
      return Ok(product);
    }

    [HttpGet, Route("category/{category}")] //https://localhost:5000/api/product/category/Chess
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get(string category)
    {
      var products = await _productRepository.GetProductsByCategoryAsync(category);
      return Ok(products);
    }

    [HttpPost, Route("")] //https://localhost:5001/api/product
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(Product))]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
      var newProduct = await _productRepository.AddProductAsync(product);
      return Ok(newProduct);
    }

    [HttpPut, Route("")] //https://localhost:5001/api/product
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable, Type = typeof(Product))]
    public async Task<IActionResult> Put([FromBody] Product product)
    {
      var prod = await _productRepository.UpdateProductAsync(product);
      return Ok(prod);
    }


    [HttpDelete, Route("{id}")] //https://localhost:5001/api/product/22
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Product))]
    public async Task<IActionResult> Delete(int id)
    {
      bool flag = await _productRepository.DeleteProductAsync(id);
      if (flag)
      {
        return RedirectToAction("Get");
      }
      return NotFound();
    }

  }
}
