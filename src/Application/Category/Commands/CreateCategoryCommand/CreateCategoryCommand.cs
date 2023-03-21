using System.ComponentModel.DataAnnotations;
using MediatR;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Category.Commands.CreateCategoryCommand;

public record CreateCategoryCommand : IRequest<int>
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.Entities.Category
        {
            Id = request.Id,
            Name = request.Name
        };
        
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}