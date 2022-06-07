using BlazorCA.Application.Common.Mappings;
using BlazorCA.Domain.Entities;

namespace BlazorCA.Application.TodoItems.Queries;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
