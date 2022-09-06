using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Companies.Request.Queries
{
    public class GetCompanyRequest : IRequest<CompanyDto>
    {
        public int CompanyId { get; set; }
    }
}
