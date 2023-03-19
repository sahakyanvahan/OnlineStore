using OnlineStore.Application.Common.Mappings;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
