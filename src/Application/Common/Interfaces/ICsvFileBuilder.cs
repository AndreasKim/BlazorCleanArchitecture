using BlazorCA.Application.TodoLists.Queries.ExportTodos;

namespace BlazorCA.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
