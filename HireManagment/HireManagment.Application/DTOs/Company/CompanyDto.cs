using HireManagment.Application.DTOs.Common;
using HireManagment.Application.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.Company
{
    public class CompanyDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }

        public int AdminId { get; set; }
        public virtual AdminApiDto? Admin { get; set; }
    }
}
