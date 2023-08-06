using System.ComponentModel.DataAnnotations.Schema;

namespace TreainBookingApi.Entities
{
    public class Passanger : EntityBase
    {
        public string Name { get; set; }
        public string Nic { get; set; }
        public string PhoneNo { get; set; }

        // Foreign key for Booking
        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        // Navigation property for Booking
        public virtual Booking Booking { get; set; }
    }
}