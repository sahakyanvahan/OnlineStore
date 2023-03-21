using OnlineStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Domain.Entities.Cart> Carts { get; }
    
    DbSet<Domain.Entities.Category> Categories { get; }
    
    DbSet<Domain.Entities.Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
