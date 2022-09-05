using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.CompanyEmployee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Request.Queries
{
    public class GetCompanyEmployeeListRequest : IRequest<List<CompanyEmployeeListDto>>
    {
    }
}
