﻿using HireManagment.Application.DTOs.Common;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.Opening
{
    public class CreateOpeningDto 
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateExpiration { get; set; }
        public OpeningType OpeningType { get; set; }

        public int CompanyEmployeeId { get; set; }
    }
}
