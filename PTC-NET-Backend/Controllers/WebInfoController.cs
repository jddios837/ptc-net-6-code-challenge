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
    public class WebInfoController : ControllerBase
    {
        private readonly PtcDbContext _context;

        public WebInfoController(PtcDbContext context)
        {
            _context = context;
        }
        
        // GET: api/WebInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebInfo>> GetWebInfo(string id)
        {
          if (_context.WebInfo == null)
          {
              return NotFound();
          }
            var webInfo = await _context.WebInfo.FindAsync(id);

            if (webInfo == null)
            {
                return NotFound();
            }

            return webInfo;
        }
    }
}
