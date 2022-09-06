using HireManagment.Application.DTOs.Common;
using HireManagment.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.CompanyEmployee
{
    public class CompanyEmployeeListDto : PersonDto
    {
        public EmployeeType EmployeeType { get; set; }
    }
}
