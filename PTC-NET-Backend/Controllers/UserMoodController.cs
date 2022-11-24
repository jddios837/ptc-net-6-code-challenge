using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PTC_NET_Backend.Data;
using PTC_NET_Backend.Models;
using PTC_NET_Backend.Models.DTO;

namespace PTC_NET_Backend.Controllers
{
    [Route("api/user/{userId:int}/driver/{driverId:int}/[controller]")]
    [ApiController]
    public class UserMoodController : ControllerBase
    {
        private readonly PtcDbContext _context;
        private readonly IMapper _mapper;
        
        public UserMoodController(PtcDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/user/1/driver/6/userMood/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<UserMood>> Get(int userId, int driverId, int id)
        {
            if (!UserExists(userId) || !DriverExists(driverId))
            {
                return NotFound();
            }
            
            var userMood = await _context.UserMoods
                .FirstOrDefaultAsync(u => u.UserId == userId && u.DriverId == driverId && u.Id == id);

            if (userMood == null)
            {
                return NotFound();
            }

            return userMood;
        }

        // POST: api/user/1/driver/6/UserMood
        [HttpPost]
        public async Task<ActionResult<UserMood>> Post(int userId, int driverId, [FromBody] UserMoodDto userMood)
        {
            if (!UserExists(userId) || !DriverExists(driverId))
            {
                return NotFound();
            }

            UserMood userMoodNew = _mapper.Map<UserMood>(userMood);
            
            _context.UserMoods.Add(userMoodNew);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("Get", new { userId, driverId, id = userMoodNew.Id }, userMoodNew);
        }

        // PUT: api/user/1/driver/6/UserMood/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<UserMood>> Put(
            int userId, 
            int driverId, 
            int id, 
            [FromBody] JsonPatchDocument<UserMoodDto> userMoodPatch)
        {
            if (!UserExists(userId) || !DriverExists(driverId))
            {
                return NotFound();
            }
            
            var userMoodDb = await _context.UserMoods
                .FirstOrDefaultAsync(u => u.UserId == userId && u.DriverId == driverId && u.Id == id);
            
            if (userMoodDb == null)
            {
                return NotFound();
            }

            UserMoodDto userMoodDtoOriginal = _mapper.Map<UserMoodDto>(userMoodDb);
            userMoodPatch.ApplyTo(userMoodDtoOriginal);
            _mapper.Map(userMoodDtoOriginal, userMoodDb);
            
            _context.Update(userMoodDb);
            await _context.SaveChangesAsync();

            return Ok(userMoodDb);
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id && e.IsDriver == false)).GetValueOrDefault();
        }
        
        private bool DriverExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id && e.IsDriver == true)).GetValueOrDefault();
        }
    }
}
