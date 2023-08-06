using System.ComponentModel.DataAnnotations.Schema;
using TreainBookingApi.Entities;

namespace TreainBookingApi.Models
{
    public class BookingVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPaid { get; set; }

        public ClassType ClassType { get; set; }
        public int PassengerCount { get; set; }

        [ForeignKey("TrainSchedule")]
        public int TrainScheduleId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        //public  IEnumerable<Passanger>? Passangers { get; set; }
    }
}