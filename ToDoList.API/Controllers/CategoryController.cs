using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/category")]
    public class CategoryController : Controller
    {
        private readonly ToDoListDbContext _context;
        public CategoryController(ToDoListDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var ctgRequest = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
                return Ok(ctgRequest);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"unexpected error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var ctgRequest = _context.Categories
                    .SingleOrDefault(u => u.CategoryId == id);
                if (ctgRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ctgRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"unspected erro{ex.Message}");
            }
        }

        [HttpPost]

        public async Task<IActionResult> PostCategory(Category category)
        {
            try
            {


                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCategoryById), category);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"unxpected error: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCategory(Category input, int id)
        {
            try
            {
                var ctgRequest = await _context.Categories.SingleOrDefaultAsync(c=>c.CategoryId == id);
                if (ctgRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    ctgRequest.Update(input.CategoryName,input.CategoryDescription);

                    _context.Categories.Update(ctgRequest); 
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

            }catch (Exception ex)
            {
                return StatusCode(500, $"unxpected error:{ex.Message}");
            }
        }
 

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCategory(Category category, int id)
        {
            try
            {
                var ctgRequest = await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);

                if(ctgRequest == null)
                {
                    return NoContent();
                }
                else
                {
                    _context.Categories.Remove(ctgRequest);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }
                
            }catch (Exception ex)
            {
                return StatusCode(500, $"unexpected error: {ex.Message}");
            }

        }
    }
}
