namespace BlazorCA.Client.Services
{
    public class ToDoListsService
    {
        private readonly swaggerClient client;

        public ToDoListsService(swaggerClient client)
        {
            this.client = client;
        }

        public async Task<long> CreateTodoItem(TodoListDto list) 
            => await client.TodoListsCreateAsync(new CreateTodoListCommand() { Title = list.Title });

        public async Task<TodosVm> GetTodoItem()
            => await client.TodoListsGetAsync();

        public async Task UpdateTodoItem(TodoListDto list)
            => await client.TodoListsUpdateAsync(list.Id ?? -1, new UpdateTodoListCommand() { Id= list.Id, Title = list.Title });

        public async Task DeleteTodoItem(TodoListDto list)
            => await client.TodoListsDeleteAsync(list.Id ?? -1);

    }
}
