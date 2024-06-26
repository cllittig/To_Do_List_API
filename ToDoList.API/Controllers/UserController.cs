﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var userRequest = await _context.Users.Where(u => !u.IsDeleted).ToListAsync();

                return Ok(userRequest);
            }catch (Exception ex)
                {
                    return StatusCode(500, $"excepted error {ex.Message}");
                }
        }


        //Rota Get baseada em um Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var userRequest = await _context.Users
                    .SingleOrDefaultAsync(u => u.UserId == id);

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

        public async Task<IActionResult> PostUser(User user)
        {
            try
            {
                //adicionando uma instancia do usuario
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

        //Rota Put para atualização
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(User userInput, int id)
        {
            try
            {
                var userRequest = await _context.Users.SingleOrDefaultAsync(d => d.UserId == id);

                if (userRequest == null)
                {
                    return NotFound();
                }

                userRequest.Update(userInput.UserFirstName, userInput.UserSecondName, userInput.UserAge, userInput.UserEmail);

                _context.Users.Update(userRequest);
                await _context.SaveChangesAsync();

                return NoContent();
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

                if (userRequest == null)
                {
                    return NoContent();
                }
                else
                {
                    userRequest.MarkAsDeleted();

                    _context.Users.Remove(userRequest);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"excepted error {ex.Message}");
            }
        }

    }
}
