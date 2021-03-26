using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportsStoreApp.Models.Abstract;
using SportsStoreApp.Models.Entities;

namespace SportsStoreApp.Models.Concrete
{
  public class EFProductRepository : IProductRepository
  {
    private readonly SportsStoreDbContext _context;
    private readonly ILogger<EFProductRepository> _logger;

    public EFProductRepository(SportsStoreDbContext sportsStoreDbContext, ILogger<EFProductRepository> logger)
    {
      _context = sportsStoreDbContext;
      _logger = logger;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
      await _context.Products.AddAsync(product);
      var recEffected = await _context.SaveChangesAsync();
      if (recEffected  == 1)
      {
        _logger.LogInformation($"***EFProductRepository.AddProductAsync, New Product: {product.ProductName}, added Successfully***");
        return product;
      }
      return null;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
      var product = await GetProductByIdAsync(productId);
      _context.Products.Remove(product);
      var recEffected = await _context.SaveChangesAsync();
      if (recEffected == 1)
      {
        _logger.LogInformation($"***EFProductRepository.DeleteProductAsync, Product with ProductId: {product.ProductId}, deleted Successfully***");
        return true;
      }
      return false;
    }

    public async Task<Product> GetProductByIdAsync(int productId) => await _context.Products.FindAsync(productId);

    public async Task<IEnumerable<Product>> GetProductsAsync() => await _context.Products.ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category) => await _context.Products.Where(p => p.Category == category).ToListAsync();

    public async Task<Product> UpdateProductAsync(Product product)
    {
      _context.Entry<Product>(product).State = EntityState.Modified;
      var recEffected = await _context.SaveChangesAsync();
      if (recEffected == 1)
      {
        _logger.LogInformation($"EFProductRepository.UpdateProductAsync, Product with ProductId: {product.ProductId}, updated Successfully");
      }
      return product;
    }
  }
}
