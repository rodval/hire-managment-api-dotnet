using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Request.Commands
{
    public class CreateCompanyEmployeeCommand : IRequest<BaseCommandResponses>
    {
        public CreateCompanyEmployeeDto CreateEmployee { get; set; }
    }
}
