namespace TreainBookingApi.Models
{
    public class TrainScheduleVM
    {
        public int Id { get; set; }
        public int AvailableSeats { get; set; }
        public bool SeatsTaken { get; set; }
        public int TrainId { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual TrainVM? Train { get; set; }
    }
}