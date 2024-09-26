using DeskManagerApi.Data;
using DeskManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskOccupancyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DeskOccupancyController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/DeskOccupancy
        [HttpPost]
        public async Task<ActionResult<DeskOccupancy>> AddDeskOccupancy(DeskOccupancy deskOccupancy)
        {
            _context.DeskOccupancies.Add(deskOccupancy);
            deskOccupancy.ReservationDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDeskOccupancyById), new { id = deskOccupancy.Id }, deskOccupancy);
        }

        // GET: api/DeskOccupancy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeskOccupancy>>> GetDeskOccupancies()
        {
            return await _context.DeskOccupancies.ToListAsync();
        }

        // GET: api/DeskOccupancy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeskOccupancy>> GetDeskOccupancyById(int id)
        {
            var deskOccupancy = await _context.DeskOccupancies.FindAsync(id);
            if (deskOccupancy == null)
            {
                return NotFound();
            }
            return deskOccupancy;
        }
    }
}
