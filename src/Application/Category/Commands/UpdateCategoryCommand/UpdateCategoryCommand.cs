using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Category.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }

    public string? Name { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);
    
        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
        }
        
        entity.Name = request.Name;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}