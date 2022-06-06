
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BreathWebAPI.Models;

namespace BreathWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapistsController : ControllerBase
    {
        private readonly BreathDbContext _context;

        public TherapistsController(BreathDbContext context)
        {
            _context = context;
        }

        // GET: api/Therapists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Therapist>>> GetTherapists()
        {
          if (_context.Therapists == null)
          {
              return NotFound();
          }
            return await _context.Therapists.ToListAsync();
        }

        // GET: api/Therapists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Therapist>> GetTherapist(int id)
        {
          if (_context.Therapists == null)
          {
              return NotFound();
          }
            var therapist = await _context.Therapists.FindAsync(id);

            if (therapist == null)
            {
                return NotFound();
            }

            return therapist;
        }

        // PUT: api/Therapists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTherapist(int id, Therapist therapist)
        {
            if (id != therapist.TherapistId)
            {
                return BadRequest();
            }

            _context.Entry(therapist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TherapistExists(id))
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

        // POST: api/Therapists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Therapist>> PostTherapist(Therapist therapist)
        {
          if (_context.Therapists == null)
          {
              return Problem("Entity set 'BreathDbContext.Therapists'  is null.");
          }
            _context.Therapists.Add(therapist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTherapist", new { id = therapist.TherapistId }, therapist);
        }

        // DELETE: api/Therapists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTherapist(int id)
        {
            if (_context.Therapists == null)
            {
                return NotFound();
            }
            var therapist = await _context.Therapists.FindAsync(id);
            if (therapist == null)
            {
                return NotFound();
            }

            _context.Therapists.Remove(therapist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TherapistExists(int id)
        {
            return (_context.Therapists?.Any(e => e.TherapistId == id)).GetValueOrDefault();
        }
    }
}
