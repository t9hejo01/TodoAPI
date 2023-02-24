using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetAllTasks()
        {
            return await _todoService.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTaskById(int id) 
        {
            var task = await _todoService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> CreateTask(TodoItem item)
        {
            var task = await _todoService.CreateTask(item);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TodoItem>>> UpdateTask(int id, TodoItem request)
        {
            var task = await _todoService.UpdateTask(id, request);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TodoItem>>> DeleteTask(int id)
        {
            var task = await _todoService.DeleteTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}

