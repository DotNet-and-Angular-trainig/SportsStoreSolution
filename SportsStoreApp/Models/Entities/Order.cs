using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStoreApp.Models.Entities
{
  public class Order
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }
    [Required, StringLength(255)]
    public string Name { get; set; }
    [Required, StringLength(150)]
    public string City { get; set; }
    [Required, StringLength(100)]
    public string State { get; set; }
    [Required, StringLength(20)]
    public string Zip { get; set; }
    [Required, StringLength(100)]
    public string Country { get; set; }
    [Required, StringLength(5)]
    public string Giftwrap { get; set; }
    [StringLength(255)]
    public string Shipped { get; set; }
  }
}
