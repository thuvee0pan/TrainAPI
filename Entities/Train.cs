namespace TreainBookingApi.Entities
{
    public class Train : EntityBase
    {
        public string Name { get; set; }
        public ClassType ClassType { get; set; }
        public int TotalSeats { get; set; }
        public int PricePerSeat { get; set; }
    }
}