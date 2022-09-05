using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Request.Command
{
    public class CreateOpeningCommand : IRequest<BaseCommandResponses>
    {
        public CreateOpeningDto CreateOpening { get; set; }
    }
}
