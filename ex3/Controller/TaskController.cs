
using ex3.Models;
using ex3.Services;
using Microsoft.AspNetCore.Mvc;

namespace ex3.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet()]
        public IEnumerable<Tasks> GetTasks()
        {
            return _taskServices.GetTasks();
        }

        [HttpPost]
        public Tasks CreateTask(Tasks task)
        {
            return _taskServices.CreateTask(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Tasks task)
        {
            if (task.Id != id)
                return BadRequest();

            _taskServices.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskServices.GetTasks().FirstOrDefault(x => x.Id == id);
            if (task == null)
                return NotFound();

            _taskServices.DeleteTask(id);
            return NoContent();
        }
        //public IActionResult getTasksUser(int userId)
        //{
        //    var task = _taskServices.GetTasks().Where(x => x.UserId == userId).ToList();
        //    if (task == null)
        //        return NotFound();

        //    _taskServices.DeleteTask(userId);
        //    return NoContent();
        //}
        [HttpGet("{userId}")]
        public IEnumerable<Tasks> getTasksUser(int userId)
        {
            return _taskServices.getTasksUser(userId);
        }
    }
}
