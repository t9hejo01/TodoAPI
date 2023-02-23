using TodoAPI.Models;

namespace TodoAPI.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> CreateTask(TodoItem item);
        Task<List<TodoItem>?> UpdateTask(int id, TodoItem request);
        Task<List<TodoItem>?> DeleteTask(int id);
        Task<List<TodoItem>> GetAllTasks();
        Task<TodoItem?> GetTaskById(int id);
    }
}
