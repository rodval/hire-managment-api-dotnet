﻿using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.DTOs.Common;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.OpeningApplication
{
    public class OpeningApplicationDto : BaseDto
    {
        public DateTime DateApplication { get; set; }
        public ApplicationStatusType Status { get; set; }

        public int CompanyEmployeeId { get; set; }
        public virtual CompanyEmployeeDto? CompanyEmployee { get; set; }

        public int CandidateId { get; set; }
        public virtual CandidateDto? Candidate { get; set; }
    }
}
