﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.DTO
{
    public class AppointmentReportDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string BranchName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}