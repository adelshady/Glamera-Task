using System;

namespace GlameraTask.Domain.Models
{
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public virtual Booking? Booking { get; set; }
        public virtual Service? Service { get; set; }
    }

}
