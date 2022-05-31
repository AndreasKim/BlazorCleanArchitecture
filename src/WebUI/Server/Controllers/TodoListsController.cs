using BlazorCA.Application.TodoLists.Commands.CreateTodoList;
using BlazorCA.Application.TodoLists.Commands.DeleteTodoList;
using BlazorCA.Application.TodoLists.Commands.UpdateTodoList;
using BlazorCA.Application.TodoLists.Queries.ExportTodos;
using BlazorCA.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCA.Server.Controllers;

public class TodoListsController : ApiControllerBase
{
    [HttpGet(Name = nameof(TodoListsGet))]
    public async Task<ActionResult<TodosVm>> TodoListsGet()
    {
        return await Mediator.Send(new GetTodosQuery());
    }

    [HttpGet("{id}", Name = nameof(TodoListsGetById))]
    public async Task<FileResult> TodoListsGetById(int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost(Name = nameof(TodoListsCreate))]
    public async Task<ActionResult<long>> TodoListsCreate(CreateTodoListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}", Name = nameof(TodoListsUpdate))]
    public async Task<ActionResult> TodoListsUpdate(long id, UpdateTodoListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(TodoListsDelete))]
    public async Task<ActionResult> TodoListsDelete(int id)
    {
        await Mediator.Send(new DeleteTodoListCommand(id));

        return NoContent();
    }
}
