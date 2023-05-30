using MediatR;
using OnlineStore.Application.Category.Commands.CreateCategoryCommand;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Cart.Commands.AddProductToCartCommand;
public class AddProductToCartCommand : IRequest<int>
{
    public int CartId { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Amount { get; set; }

    public int CategoryId { get; set; }
}

public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IBus _bus;

    public AddProductToCartCommandHandler(IApplicationDbContext context, IBus bus)
    {
        _context = context;
        _bus = bus;
    }

    public async Task<int> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
    {
        var product = new OnlineStore.Domain.Entities.Product()
        {
            CartId = request.CartId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Amount = request.Amount,
            CategoryId = request.CategoryId,
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync(cancellationToken);

        await _bus.ReceiveAsync<CreateCategoryCommand>("products", x =>
        {
            //TODO: Add some logic here later
        });


        return product.Id;
    }
}