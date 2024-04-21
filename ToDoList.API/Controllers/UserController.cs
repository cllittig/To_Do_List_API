using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/users")]
    public class UserController :ControllerBase
    {

        private readonly ToDoListDbContext _context;

        //injeção de dependencia
        public UserController(ToDoListDbContext context)
        {
            _context = context;
        }


        //Rota Get geral
        [HttpGet]

        public IActionResult GetAllUsers()
        {
            try
            {
                var userRequest = _context.Users.Where(u => !u.IsDeleted).ToList();

                return Ok(userRequest);
            }catch (Exception ex)
                {
                    return StatusCode(500, $"excepted error {ex.Message}");
                }
        }


        //Rota Get baseada em um Id
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var userRequest = _context.Users
                    .SingleOrDefault(u => u.UserId == id);

                if (userRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(userRequest);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        //Rota post 
        [HttpPost]

        public IActionResult PostUser(User user)
        {
            try
            {
                //adicionando uma instancia do usuario
                _context.Users.Add(user);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        //Rota Put para atualização
        [HttpPut("{id}")]

        public IActionResult UpdateUser(User userInput, int id)
        {
            try
            {
                var userRequest = _context.Users.SingleOrDefault(d => d.UserId == id);

                if (userRequest == null)
                {
                    return NotFound();
                }

                userRequest.Update(userInput.UserFirstName, userInput.UserSecondName, userInput.UserAge, userInput.UserEmail);

                _context.Users.Update(userRequest);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }


        }

        //Rota para deletar um usuario baseado no id
        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id)
        {
            try
            {
                var userRequest = _context.Users.SingleOrDefault(d => d.UserId == id);

                userRequest.MarkAsDeleted();

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

    }
}
