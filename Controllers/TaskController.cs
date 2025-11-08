using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMasterAPI.Services;

namespace TaskMasterAPI.Controllers
{
    //api/task
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Task>> GetTasks()
        {
            return Ok(TaskDataStore.Current.Tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Task> GetTask (int id)
        {
            var task = TaskDataStore.Current.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound("No se encontro la tarea");
            }

            return Ok(task);
        }
    }
}
