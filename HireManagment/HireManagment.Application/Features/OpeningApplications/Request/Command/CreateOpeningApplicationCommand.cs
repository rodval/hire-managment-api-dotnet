using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Request.Command
{
    public class CreateOpeningApplicationCommand : IRequest<BaseCommandResponses>
    {
        public CreateOpeningApplicationDto CreateOpeningApplication { get; set; }
    }
}
