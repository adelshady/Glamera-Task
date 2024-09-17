﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlameraTask.Application.Common.SharedDto
{
    public class PaginationRequest
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;

    }
}
