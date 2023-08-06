using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreainBookingApi.Entities;
using TreainBookingApi.Helpers;
using TreainBookingApi.Models;

namespace TreainBookingApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookingController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetEntities()
        {
            return await _context.Booking
                             .Include(x => x.TrainSchedule)
                             .Include(x => x.User)
                                    .ToListAsync();
        }

        // GET: api/Entities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetEntity(int id)
        {
            var entity = await _context.Booking
                                    .Include(x => x.TrainSchedule)
                                    .Include(x => x.User)
                                    .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, Booking entity)
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
        public async Task<ActionResult<Booking>> PostEntity(BookingVM entity)
        {
            try
            {
                var booking = _mapper.Map<Booking>(entity);

                //foreach (var passenger in booking.Passangers)
                //{
                //    passenger.Booking = booking;
                //}

                _context.Booking.Add(booking);

                var trainSchedule = await _context.TrainSchedule.FindAsync(entity.TrainScheduleId);
                if (trainSchedule == null)
                {
                    throw new AppException("trainSchedule not found");
                }

                if (trainSchedule.AvailableSeats < booking.PassengerCount)
                {
                    throw new AppException("Seats are not available");
                }
                trainSchedule.AvailableSeats -= booking.PassengerCount;

                _context.Entry(trainSchedule).State = EntityState.Detached;
                await _context.SaveChangesAsync();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // DELETE: api/Entities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _context.Booking.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}