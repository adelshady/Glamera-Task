

namespace GlameraTask.Domain.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } // Could be "Male", "Female", etc.
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }

        // Navigation property
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
