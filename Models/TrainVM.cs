using TreainBookingApi.Entities;

namespace TreainBookingApi.Models
{
    public class TrainVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassType ClassType { get; set; }
        public int TotalSeats { get; set; }
        public int PricePerSeat { get; set; }
    }
}