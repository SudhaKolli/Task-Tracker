using Microsoft.EntityFrameworkCore;
using Task_Tracker.Data;
using Task_Tracker.Models;

namespace Task_Tracker.Repositories
{
    public class TaskRepository  :ITaskRepository   {

        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
           return  await  _context.Tasks.ToListAsync();
        }
        public async Task<TaskModel> GetTaskById(int taskId)
        {
           return await _context.Tasks.FindAsync(taskId);
        }
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<bool> UpdateTask(int taskId, string taskName, bool isCompleted)
        {
            var task = await GetTaskById(taskId);

            task.Title = taskName;
            task.IsCompleted = isCompleted;
            _context.Update(task);
           int res= _context.SaveChanges();
            return res>0;
        }
        public async Task<bool> DeleteTask(int taskId)
        {
            TaskModel taskModel = await GetTaskById(taskId);
            _context.Tasks.Remove(taskModel);
            int res = _context.SaveChanges();
            return res > 0;
        }
    }
}
