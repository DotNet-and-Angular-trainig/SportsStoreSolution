using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStoreApp.Models.Entities
{
  public class OrderDetail
  {
    [Key]
    [Column (Order = 1)]
    public int OrderId { get; set; }
    [Key]
    [Column (Order = 2)]
    public int ProductId { get; set; }
    [Required, StringLength(100)]
    public string ProductName { get; set; }
    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Required]
    public int Count { get; set; }
  }
}
