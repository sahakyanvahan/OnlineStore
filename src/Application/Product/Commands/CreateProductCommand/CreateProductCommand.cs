using System.ComponentModel.DataAnnotations;
using MediatR;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Product.Commands.CreateProductCommand;

public class CreateProductCommand : IRequest<int>
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public decimal? Price { get; set; }
    
    [Required]
    public int? Amount { get; set; }

    public int CategoryId { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Amount = request.Amount,
            CategoryId = request.CategoryId
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}