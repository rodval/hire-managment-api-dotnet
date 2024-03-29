﻿using HireManagment.Application.DTOs.Common;
using HireManagment.Application.DTOs.Company;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.CompanyEmployee
{
    public class CompanyEmployeeDto : PersonDto
    {
        public EmployeeType EmployeeType { get; set; }

        public int CompanyId { get; set; }
        public virtual CompanyDto? Company { get; set; }
    }
}
