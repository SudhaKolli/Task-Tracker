using Task_Tracker.Data;
using Task_Tracker.Models;

namespace Task_Tracker.Repositories
{
    public class TaskRepository :ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            
        }
        public async Task<TaskModel> GetTaskById(int taskId)
        {

        }
        public async Task<bool> UpdateTask(int taskId, string taskName)
        {

        }
        public async Task<bool> DeleteTask(int taskId)
        {

        }
    }
}
