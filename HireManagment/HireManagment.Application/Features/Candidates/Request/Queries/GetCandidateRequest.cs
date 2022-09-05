using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Candidate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Request.Queries
{
    public class GetCandidateRequest : IRequest<CandidateDto>
    {
        public int CandidateId { get; set; }
    }
}
