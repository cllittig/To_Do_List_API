using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.API.Entities;
using ToDoList.API.Persistence;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/to-do-list/Address")]
    public class AddressController : Controller
    {
        private readonly ToDoListDbContext _context;

        public AddressController(ToDoListDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                var AddressRequest = await _context.Addresses.ToListAsync();

                if (AddressRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(AddressRequest);
                }
            } catch (Exception ex)
            {
                return StatusCode(500, $"unexpected error {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                var addressRequest = await _context.Addresses.SingleOrDefaultAsync(a => a.AddressId == id);

                if (addressRequest == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(addressRequest);
                }
            }catch (Exception ex)
            {
                return StatusCode(500, $"unexpected error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAddressById), new { id = address.AddressId }, address);

            }catch (Exception ex)
            {
                return StatusCode(500, $"unexpected error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAddress(int id, Address input)
        {
            try
            {

                var addressRequest = await _context.Addresses.SingleOrDefaultAsync(a => a.AddressId == id);

                if (addressRequest == null)
                {
                    return NotFound();
                }
                else
                {
                    addressRequest.Update(input.AddressStreet, input.AddressNumber, input.AddressComplement, input.AddressCity, input.AddressState, input.AddressPostalCode);
                    await _context.SaveChangesAsync();

                    return NoContent();

                }

            }catch (Exception ex)
            {
                return StatusCode(500, $"unexpected erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            try
            {
                var addressRequest = await _context.Addresses.SingleOrDefaultAsync(a => a.AddressId == id);

                if (addressRequest == null)
                {
                    return NoContent();

                }
                else
                {
                    _context.Addresses.Remove(addressRequest);
                    await _context.SaveChangesAsync();

                    return NoContent();
                }

            }catch(Exception ex)
            {
                return StatusCode(500, $"Unexpected erro: {ex.Message}");
            }
        }

    }
}
