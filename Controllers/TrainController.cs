using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreainBookingApi.Entities;
using TreainBookingApi.Helpers;

namespace TreainBookingApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TrainController : ControllerBase
    {
        private readonly DataContext _context;

        public TrainController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetEntities()
        {
            return await _context.Train.ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetEntity(int id)
        {
            var entity = await _context.Train.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, Train entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
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

        // POST: api/Entities
        [HttpPost]
        public async Task<ActionResult<Train>> PostEntity(Train entity)
        {
            _context.Train.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntity", new { id = entity.Id }, entity);
        }

        // DELETE: api/Entities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _context.Train.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Train.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Train.Any(e => e.Id == id);
        }
    }
}