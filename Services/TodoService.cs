using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;


namespace TodoAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly DataContext _context;
    
        public TodoService(DataContext context)
        {
           
            _context = context;
        }

        public async Task<List<TodoItem>> CreateTask(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>?> DeleteTask(int id)
        {
            var task = await _context.TodoItems.FindAsync(id);
            if (task == null)
            {
                return null;
            }

             _context.TodoItems.Remove(task);
            await _context.SaveChangesAsync();

            return await _context.TodoItems.ToListAsync();
        }

        public async Task<List<TodoItem>> GetAllTasks()
        {
            var tasks = await _context.TodoItems.ToListAsync();
            return tasks;
        }

        public async Task<TodoItem?> GetTaskById(int id)
        {
            var task = await _context.TodoItems.FindAsync(id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<List<TodoItem>?> UpdateTask(int id, TodoItem request)
        {
            var task = await _context.TodoItems.FindAsync(id);
            if(task == null)
            {
                return null;
            }

            task.Name = request.Name;
            task.Description = request.Description;
            task.CreatedDate = request.CreatedDate;
            task.UpdatedDate = request.UpdatedDate;
            task.IsComplete = request.IsComplete;

            await _context.SaveChangesAsync();

            return await _context.TodoItems.ToListAsync();
        }
    }
}
