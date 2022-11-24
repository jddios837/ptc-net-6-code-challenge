using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTC_NET_Backend.Data;
using PTC_NET_Backend.Models;

namespace PTC_NET_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly PtcDbContext _context;

        public QuestionController(PtcDbContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mood>>> GetMoods()
        {
          if (_context.Moods == null)
          {
              return NotFound();
          }
            return await _context.Moods.ToListAsync();
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mood>> GetMood(int id)
        {
          if (_context.Moods == null)
          {
              return NotFound();
          }
            var mood = await _context.Moods.FindAsync(id);

            if (mood == null)
            {
                return NotFound();
            }

            return mood;
        }

        // PUT: api/Question/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMood(int id, Mood mood)
        {
            if (id != mood.Id)
            {
                return BadRequest();
            }

            _context.Entry(mood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoodExists(id))
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

        // POST: api/Question
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mood>> PostMood(Mood mood)
        {
          if (_context.Moods == null)
          {
              return Problem("Entity set 'PtcDbContext.Moods'  is null.");
          }
            _context.Moods.Add(mood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMood", new { id = mood.Id }, mood);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMood(int id)
        {
            if (_context.Moods == null)
            {
                return NotFound();
            }
            var mood = await _context.Moods.FindAsync(id);
            if (mood == null)
            {
                return NotFound();
            }

            _context.Moods.Remove(mood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoodExists(int id)
        {
            return (_context.Moods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
