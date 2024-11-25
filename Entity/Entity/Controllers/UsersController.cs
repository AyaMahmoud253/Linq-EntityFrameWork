using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity.Models;
using System.Formats.Asn1;
namespace Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor that injects the ApplicationDbContext
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest();
            }

            // Map UserDTO to User entity
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email
                // Map other properties as needed
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // Find the user by ID
            var user = await _context.Users.FindAsync(id);

            // If user is not found, return 404 Not Found
            if (user == null)
            {
                return NotFound();
            }

            // Return the user data
            return user;
        }
    }
}