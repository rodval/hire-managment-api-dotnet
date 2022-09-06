using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Request.Command
{
    public class DeleteOpeningApplicationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
