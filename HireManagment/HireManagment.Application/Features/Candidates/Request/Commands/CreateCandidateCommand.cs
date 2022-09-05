using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Request.Commands
{
    public class CreateCandidateCommand : IRequest<BaseCommandResponses>
    {
        public CreateCandidateDto CreateCandidate { get; set; }
    }
}
