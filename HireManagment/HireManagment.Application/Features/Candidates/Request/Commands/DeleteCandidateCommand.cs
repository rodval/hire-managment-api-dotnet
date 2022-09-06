using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Request.Commands
{
    public class DeleteCandidateCommand : IRequest
    {
        public int Id { get; set; }
    }
}
