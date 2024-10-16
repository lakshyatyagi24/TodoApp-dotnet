using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private static List<TodoItem> todoList = new List<TodoItem>();

    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
    {
        return todoList;
    }

    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetTodoItem(long id)
    {
        var item = todoList.Find(t => t.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    [HttpPost]
    public ActionResult<TodoItem> CreateTodoItem(TodoItem item)
    {
        item.Id = todoList.Count + 1;
        todoList.Add(item);
        return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodoItem(long id)
    {
        var item = todoList.Find(t => t.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        todoList.Remove(item);
        return NoContent();
    }
}
