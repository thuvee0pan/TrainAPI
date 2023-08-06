using System.ComponentModel.DataAnnotations.Schema;

namespace TreainBookingApi.Entities
{
    public class Booking : EntityBase
    {
        public string Title { get; set; }
        public bool IsPaid { get; set; }
        public ClassType ClassType { get; set; }
        public int PassengerCount { get; set; }

        [ForeignKey("TrainSchedule")]
        public int TrainScheduleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public TrainSchedule TrainSchedule { get; set; }
        public virtual User User { get; set; }
        //public virtual IEnumerable<Passanger>? Passangers { get; set; }
    }
}