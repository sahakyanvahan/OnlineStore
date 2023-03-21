using System.ComponentModel.DataAnnotations;
using MediatR;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Cart.Commands.CreateCartCommand;

public class CreateCartCommand : IRequest<int>
{
    public int Id { get; init; }

    [Required]
    public string? Name { get; init; }
    
    public string? ImageUrl { get; init; }
    
    [Required]
    public decimal? Price { get; init; }
    
    public int? Quantity { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateCartCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var entity = new OnlineStore.Domain.Entities.Cart
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity
        };

        await _context.Carts.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
