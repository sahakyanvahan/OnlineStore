using MediatR;
using OnlineStore.Application.Common.Exceptions;
using OnlineStore.Application.Common.Interfaces;

namespace OnlineStore.Application.Category.Commands.DeleteCategoryCommand;

public record DeleteCategoryCommand(int Id) : IRequest;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }
        
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}