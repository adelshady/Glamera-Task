
namespace GlameraTask.Domain.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } 
        public DateTime PaymentDate { get; set; }
        public  virtual Booking? Booking { get; set; }
    }

}
