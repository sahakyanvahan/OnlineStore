using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Product.Queries;

public class ProductDto : IMapFrom<Domain.Entities.Product>
{
    public int Id { get; set; }

    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? ImageUrl { get; set; }
    
    public decimal? Price { get; set; }
    
    public int? Amount { get; set; }

    public int CategoryId { get; set; }
}