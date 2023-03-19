using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Domain.Entities;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}