namespace BlazorCA.Client.Services
{
    public class ToDoItemService
    {
        private readonly swaggerClient client;

        public ToDoItemService(swaggerClient client)
        {
            this.client = client;
        }

        public async Task<long> CreateTodoItem(TodoItemDto item) 
            => await client.TodoItemCreateAsync(new CreateTodoItemCommand() { ListId= item.Id, Title = item.Title });

        public async Task UpdateTodoItem(TodoItemDto item)
            => await client.TodoItemUpdateAsync(item.Id ?? -1, new UpdateTodoItemCommand() { Id=item.Id, Title = item.Title, Done = item.Done });

        public async Task DeleteTodoItem(TodoItemDto item)
            => await client.TodoItemDeleteAsync(item.Id ?? -1);

    }
}
