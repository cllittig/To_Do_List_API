using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/task-tag")]
    public class TaskTagController : ControllerBase
    {
        private readonly ToDoListDbContext _context;

        public TaskTagController(ToDoListDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskTag()
        {
            try
            {
                var taskTagRequest = await _context.TaskTags.ToListAsync();

                return Ok(taskTagRequest);
            }catch (Exception ex)
            {
                return StatusCode(500, $"unxpected error {ex.Message}");
            }

        }

        [HttpGet("{Taskid}/ {TagId}")]
        public async Task<IActionResult> GetAllByTaskTagId(int Taskid, int TagId)
        {
            try
            {
                var taskTagRequest = await _context.TaskTags.SingleOrDefaultAsync(tt => tt.TaskId == Taskid && tt.TagId == TagId);
                if (taskTagRequest == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(taskTagRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"unxpected error {ex.Message}");
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostTaskTag(TaskTag taskTag)
        {
            try
            {
                _context.TaskTags.Add(taskTag);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAllByTaskTagId), new { TaskId = taskTag.TaskId, TagId = taskTag.TagId }, taskTag) ;
            }catch (Exception ex)
            {
                return StatusCode(500, $"unxpected error: {ex.Message}");
            }
        }
    }
}
