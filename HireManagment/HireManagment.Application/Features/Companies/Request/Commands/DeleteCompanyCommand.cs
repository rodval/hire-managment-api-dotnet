using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Companies.Request.Commands
{
    public class DeleteCompanyCommand : IRequest
    {
        public int Id { get; set; }
    }
}
