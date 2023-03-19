using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities;

public class Cart
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    
    public string? ImageUrl { get; set; }
    
    [Required]
    public decimal? Price { get; set; }
    
    public int? Quantity { get; set; }
}