using BlazorCA.Application.Common.Mappings;
using BlazorCA.Domain.Entities;

namespace BlazorCA.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
