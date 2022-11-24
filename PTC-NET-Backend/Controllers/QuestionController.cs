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
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
          if (_context.Question == null)
          {
              return NotFound();
          }
            return await _context.Question.ToListAsync();
        }
    }
}
