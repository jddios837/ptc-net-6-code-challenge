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
    public class MoodController : ControllerBase
    {
        private readonly PtcDbContext _context;

        public MoodController(PtcDbContext context)
        {
            _context = context;
        }

        // GET: api/Mood
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mood>>> GetMoods()
        {
            if (_context.Moods == null)
            {
                return NotFound();
            }

            return await _context.Moods.ToListAsync();
        }
    }
}
