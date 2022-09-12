using HireManagment.Application.DTOs.CompanyEmployee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Request.Queries
{
    public class GetCompanyEmployeeRequest : IRequest<CompanyEmployeeDto>
    {
        public string CompanyEmployeeId { get; set; }
    }
}
