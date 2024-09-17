using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.DTO
{
    public class CustomerDemographicsDto
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string BranchName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
