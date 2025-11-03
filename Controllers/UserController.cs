using firstAPI.Data;
using firstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            _context.FirstAPI.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.FirstAPI.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.FirstAPI.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.FirstAPI.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found!");
            }

            _context.Entry(user).CurrentValues.SetValues(updatedUser);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.FirstAPI.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.FirstAPI.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}