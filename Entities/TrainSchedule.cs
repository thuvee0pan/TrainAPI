using System.ComponentModel.DataAnnotations.Schema;

namespace TreainBookingApi.Entities
{
    public class TrainSchedule : EntityBase
    {

        public int AvailableSeats { get; set; }
        public bool SeatsTaken { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual Train Train { get; set; }
    }
}