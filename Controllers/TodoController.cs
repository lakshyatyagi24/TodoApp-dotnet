using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    // Thread-safe collection to manage Todo items
    private static ConcurrentDictionary<long, TodoItem> todoList = new ConcurrentDictionary<long, TodoItem>();

    // Atomic counter for unique ID generation
    private static long currentId = 0;

    // GET: api/todo
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
    {
        // Return a 200 OK with the list of Todo items
        return Ok(todoList.Values);
    }

    // GET: api/todo/{id}
    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetTodoItem(long id)
    {
        // Try to find the item by its ID
        if (todoList.TryGetValue(id, out var item))
        {
            return Ok(item); // Return 200 OK with the item
        }

        return NotFound(); // Return 404 Not Found if the item doesn't exist
    }

    // POST: api/todo
    [HttpPost]
    public ActionResult<TodoItem> CreateTodoItem(TodoItem item)
    {
        // Simple validation to ensure the task name is not empty
        if (string.IsNullOrEmpty(item.Name))
        {
            return BadRequest("Task name cannot be empty.");
        }

        // Generate a unique ID for the new Todo item
        item.Id = System.Threading.Interlocked.Increment(ref currentId);

        // Add the new item to the thread-safe collection
        todoList[item.Id] = item;

        // Return 201 Created with the location of the new resource
        return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
    }

    // DELETE: api/todo/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTodoItem(long id)
    {
        // Try to remove the item by its ID
        if (!todoList.TryRemove(id, out _))
        {
            return NotFound(); // Return 404 Not Found if the item doesn't exist
        }

        return NoContent(); // Return 204 No Content on successful delete
    }

    // PUT: api/todo/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTodoItem(long id, TodoItem updatedItem)
    {
        // Ensure the task name is not empty
        if (string.IsNullOrEmpty(updatedItem.Name))
        {
            return BadRequest("Task name cannot be empty.");
        }

        // Check if the item exists
        if (!todoList.ContainsKey(id))
        {
            return NotFound(); // Return 404 Not Found if the item doesn't exist
        }

        // Update the existing item
        var existingItem = todoList[id];
        existingItem.Name = updatedItem.Name;
        existingItem.IsComplete = updatedItem.IsComplete;

        // Update the collection with the modified item
        todoList[id] = existingItem;

        return NoContent(); // Return 204 No Content on successful update
    }
}
