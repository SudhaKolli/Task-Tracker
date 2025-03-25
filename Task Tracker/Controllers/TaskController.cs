using Microsoft.AspNetCore.Mvc;
using Task_Tracker.Models;
using Task_Tracker.Repositories;

namespace Task_Tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            return await _taskRepository.GetAllTasks();
        }
        [HttpGet("{id}")]
        public async Task<TaskModel> GetTask(int id)
        {
            return await _taskRepository.GetTaskById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Task>> AddTask(TaskModel task)
        {
            var newTask = await _taskRepository.AddTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}/{title}/{isCompleted}")]
        public async Task<IActionResult> UpdateTask(int id, string title, bool isCompleted)
        {
            await _taskRepository.UpdateTask(id, title,isCompleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskRepository.DeleteTask(id);
            if (!success) return NotFound();
            return NoContent();
        }


    }
}
