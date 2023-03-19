using OnlineStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
    DbSet<Cart> Carts { get; }
    
    DbSet<Category> Categories { get; }
    
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
