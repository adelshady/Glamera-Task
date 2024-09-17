using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.DTO
{
    public class BookingReportDto
    {
        public int BookingId { get; set; }          
        public string BranchName { get; set; }      
        public DateTime BookingDate { get; set; }   
        public string Status { get; set; }          
        public List<string> Services { get; set; }  

        
        public string ClientName { get; set; }      
        public decimal TotalAmount { get; set; }    
    }
}
