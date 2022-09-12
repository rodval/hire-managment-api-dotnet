using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Request.Commands
{
    public class DeleteCompanyEmployeeCommand : IRequest
    {
        public string Id { get; set; }
    }
}
