using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? ImageUrl { get; set; }
    
    [Required]
    public decimal? Price { get; set; }
    
    [Required]
    public int? Amount { get; set; }

    public Category Category { get; set; }
    
    public int CategoryId { get; set; }
}