using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/tasks")]
    public class TaskController : ControllerBase
    {

        private readonly ToDoListDbContext _context;

        public TaskController(ToDoListDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasksRequest = await _context.Tasks.Where(tk => !tk.IsDeleted).ToListAsync();

                return Ok(tasksRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetTasksById(int id)
        {
            try
            {
                var taskRequest = _context.Tasks.SingleOrDefault(tk => tk.TaskId == id);

                if (taskRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(taskRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTask(Tasks task)
        {
            try
            {
                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTasksById), new { id = task.TaskId }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Task taskInput, int id) 
        {
            try
            {
                var taskRequest = await _context.Tasks.SingleOrDefaultAsync(d => d.TaskId == id);

                if (taskRequest == null)
                {
                    return NotFound();
                }

                taskRequest.Update(taskRequest.TaskTitle, taskRequest.TaskDescription, taskRequest.TaskPriority, taskRequest.TaskStatus);
                _context.Tasks.Update(taskRequest);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var taskRequest = await _context.Tasks.SingleOrDefaultAsync(d => d.TaskId == id);

                taskRequest.MarkIsDeleted();

                _context.Tasks.Remove(taskRequest); 
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

    }
}
