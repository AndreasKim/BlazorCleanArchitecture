using BlazorCA.Application.TodoItems.Commands.CreateTodoItem;
using BlazorCA.Application.TodoItems.Commands.DeleteTodoItem;
using BlazorCA.Application.TodoItems.Commands.UpdateTodoItem;
using BlazorCA.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCA.Server.Controllers;

public class TodoItemsController : ApiControllerBase
{

    [HttpPost(Name = nameof(TodoItemCreate))]
    public async Task<ActionResult<long>> TodoItemCreate(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}", Name = nameof(TodoItemUpdate))]
    public async Task<ActionResult> TodoItemUpdate(long id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]", Name = nameof(TodoItemUpdateItemDetails))]
    public async Task<ActionResult> TodoItemUpdateItemDetails(long id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}", Name = nameof(TodoItemDelete))]
    public async Task<ActionResult> TodoItemDelete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}

