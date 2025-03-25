using Task_Tracker.Models;

namespace Task_Tracker.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int taskId);
        Task<bool> UpdateTask(int taskId, string taskName, bool isCompleted);
        Task<bool> DeleteTask(int taskId);
        Task<TaskModel> AddTask(TaskModel task);
    }
}
