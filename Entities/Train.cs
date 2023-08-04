using System.ComponentModel.DataAnnotations.Schema;

namespace TreainBookingApi.Entities
{
    public class Train : EntityBase
    {
        public string Name { get; set; }
        public string Locomotive { get; set; }

        [ForeignKey("RailroadCar")]
        public int RailroadCarId { get; set; }

        public virtual RailroadCar RailroadCar { get; set; }
        public decimal RailroadCarAmount { get; set; }
    }
}