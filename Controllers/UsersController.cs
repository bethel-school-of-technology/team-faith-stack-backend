
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BreathWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BreathWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BreathDbContext _context;

        public UsersController(BreathDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost, Authorize]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
          //if (_context.Users == null)
          //{
              //return Problem("Entity set 'BreathDbContext.Users'  is null.");
          //}
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return BadRequest("Invalid client request");
          }

          if (user.UserName == user.UserName && user.Password == user.Password && user.FirstName == user.FirstName && user.LastName == user.LastName && user.Email == user.Email)
          {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7102",
                    audience: "https://localhost:7102",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
          
                );
          
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return Ok(new AuthResponse { Token = tokenString });
          }

          return Unauthorized();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);

        }


        // DELETE: api/Users/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
