using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admins.Request.Commands
{
    public class CreateAdminCommand : IRequest<BaseCommandResponses>
    {
        public CreateAdminApiDto CreateAdminApi { get; set; }
    }
}
