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
    public class TrainScheduleController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrainScheduleController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Entities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainSchedule>>> GetEntities(string? DepartureCity, string? ArrivalCity, DateTime? DepartureTime, DateTime? ArrivalTime, int? seats)
        {
            var trainSchedule = await _context.TrainSchedule.Include(x => x.Train).ToListAsync();
            if (DepartureCity != null)
            {
                trainSchedule = trainSchedule.Where(x => x.DepartureCity == DepartureCity).ToList();
            }
            if (ArrivalCity != null)
                trainSchedule = trainSchedule.Where(x => x.ArrivalCity == ArrivalCity).ToList();
            if (DepartureTime != null)
                trainSchedule = trainSchedule.Where(x => x.DepartureTime.Date == DepartureTime?.Date).ToList();
            if (DepartureCity != null)
                trainSchedule = trainSchedule.Where(x => x.ArrivalTime.Date == ArrivalTime?.Date).ToList();
            if (DepartureCity != null)
                trainSchedule = trainSchedule.Where(x => x.AvailableSeats >= seats).ToList();

            return trainSchedule;
        }

        // GET: api/Entities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainSchedule>> GetEntity(int id)
        {
            var entity = await _context.TrainSchedule.Include(x => x.Train).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Entities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, TrainSchedule entity)
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
        public async Task<ActionResult<TrainSchedule>> PostEntity(TrainScheduleVM entity)
        {
            try
            {
                TrainSchedule trainSchedule = _mapper.Map<TrainSchedule>(entity);

                var train = await _context.Train.FindAsync(trainSchedule.TrainId);

                if (train == null)
                {
                    throw new AppException("Train Not Found");
                }

                trainSchedule.AvailableSeats = train.TotalSeats;
                trainSchedule.DepartureTime = trainSchedule.DepartureTime;
                var model = _context.TrainSchedule.Add(trainSchedule);
                await _context.SaveChangesAsync();
                entity.Id = model.Entity.Id;
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Entities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _context.TrainSchedule.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.TrainSchedule.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.TrainSchedule.Any(e => e.Id == id);
        }
    }
}