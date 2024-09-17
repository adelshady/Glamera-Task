using System;
using System.Collections.Generic;
namespace GlameraTask.Domain.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
