using HireManagment.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.DTOs.Admin
{
    public class AdminApiListDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
