using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("to-do-list/user")]
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

        public IActionResult GetAll()
        {
            var userRequest = _context.Users.Where(u => !u.IsDeleted).ToList();

            return Ok(userRequest);
        }


        //Rota Get baseada em um Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userRequest = _context.Users
                .SingleOrDefault(u=> u.UserId == id);

            if(userRequest == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userRequest);
            }
        }

        //Rota post 
        [HttpPost]

        public IActionResult Post(User user)
        {
            //adicionando uma instancia do usuario
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        //Rota Put para atualização
        [HttpPut("{id}")]

        public IActionResult Update(User userInput, int id)
        {
            var userRequest = _context.Users.SingleOrDefault(d => d.UserId == id);

            if(userRequest == null)
            {
                return NotFound();
            }

            userRequest.Update(userInput.UserFirstName, userInput.UserSecondName, userInput.UserAge, userInput.UserEmail);

            _context.Users.Update(userRequest);
            _context.SaveChanges();

            return NoContent();


        }

        //Rota para deletar um usuario baseado no id
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var userRequest = _context.Users.SingleOrDefault(d => d.UserId == id);

            userRequest.MarkAsDeleted();

            _context.SaveChanges();

            return NoContent();
        }

    }
}
