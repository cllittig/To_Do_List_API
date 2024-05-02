using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/tag")]
    public class TagController : Controller
    {
        private readonly ToDoListDbContext _context;

        //injeção de dependencia
        public TagController(ToDoListDbContext context)
        {
            _context = context;
        }


        //Rota Get geral
        [HttpGet]
        public async Task<IActionResult> GetAllTag()
        {
            try
            {
                var tagRequest = await _context.Users.Where(tg => !tg.IsDeleted).ToListAsync();

                return Ok(tagRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }


        //Rota Get baseada em um Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            try
            {
                var tagRequest = await _context.Tags
                    .SingleOrDefaultAsync(u => u.TagId == id);

                if (tagRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tagRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        //Rota post 
        [HttpPost]

        public async Task<IActionResult> PostTag(Tag tag)
        {
            try
            {
                //adicionando uma instancia do usuario
                _context.Tags.Add(tag);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetTagById), new { id = tag.TagId }, tag);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        //Rota Put para atualização
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTag(User userInput, int id)
        {
            try
            {
                var userRequest = await _context.Users.SingleOrDefaultAsync(d => d.UserId == id);

                if (userRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    userRequest.Update(userInput.UserFirstName, userInput.UserSecondName, userInput.UserAge, userInput.UserEmail);
    
                    _context.Users.Update(userRequest);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }


        }

        //Rota para deletar um usuario baseado no id
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var userRequest = await _context.Users.SingleOrDefaultAsync(d => d.UserId == id);

                userRequest.MarkAsDeleted();

                _context.Users.Remove(userRequest);
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

