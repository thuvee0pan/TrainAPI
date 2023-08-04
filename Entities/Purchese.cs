using System.ComponentModel.DataAnnotations.Schema;

namespace TreainBookingApi.Entities
{
    public class Purchese : EntityBase
    {
        [ForeignKey("TrainRoute")]
        public int TrainRouteId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public int railroadCarNumber { get; set; }
        public string SeatsArray { get; set; }
        public decimal Price { get; set; }
        public bool Paid { get; set; }
        public virtual TrainRoute TrainRoute { get; set; }
        public virtual User User { get; set; }
    }
}