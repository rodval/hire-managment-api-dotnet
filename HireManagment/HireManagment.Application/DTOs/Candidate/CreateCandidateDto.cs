﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.Candidate
{
    public class CreateCandidateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
