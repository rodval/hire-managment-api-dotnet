using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Companies.Request.Commands
{
    public class CreateCompanyCommand : IRequest<BaseCommandResponses>
    {
        public CreateCompanyDto CreateCompany { get; set; }
    }
}
