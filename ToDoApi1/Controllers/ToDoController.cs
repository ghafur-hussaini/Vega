using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApi1.Controllers
{

    [Route("api/[Controller]")]
        [ApiController]
        public class TodoController : ControllerBase
        {
            private readonly ToDoContext _context;

        public TodoController(ToDoContext context)
        {
            _context = context;

            if (_context.Todoitems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Todoitems.Add(new ToDoItems { Name = "Item1" });
                _context.SaveChanges();
            }
        }
                  // GET: api/Todo
    [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItems>>> GetTodoItems()
        {
            return await _context.Todoitems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItems>> GetTodoItem(long id)
        {
            var todoItem = await _context.Todoitems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<ToDoItems>> PostTodoItem([FromBody]ToDoItems item)
        {
            _context.Todoitems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }
        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, ToDoItems item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
        }
  


  