using OnlineStore.Application.TodoLists.Queries.ExportTodos;

namespace OnlineStore.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
