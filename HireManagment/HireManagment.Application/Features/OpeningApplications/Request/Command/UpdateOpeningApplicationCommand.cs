using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Request.Command
{
    public class UpdateOpeningApplicationCommand : IRequest<Unit>
    {
        public UpdateOpeningApplicationDto OpeningApplication { get; set; }
    }
}
