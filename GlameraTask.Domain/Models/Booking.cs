
namespace GlameraTask.Domain.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; } 
        public string Status { get; set; } 
        public virtual Client? Client { get; set; }
        public virtual Branch? Branch { get; set; }
        public List<BookingService>? BookingServices { get; set; } = new List<BookingService>();
    }

}
