using MediatR;
using OnlineStore.Application.Category.Commands.UpdateCategoryCommand;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Product.Commands.UpdateProductCommand;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal? Price { get; set; }
    
    public int? Amount { get; set; }

    public int CategoryId { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);
    
        if (product == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);
        }
        
        product.Name = request.Name;
        product.Description = request.Description;
        product.Name = request.Name;
        product.Price = request.Price;
        product.Amount = request.Amount;
        product.CategoryId = request.CategoryId;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}