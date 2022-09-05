using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Candidates.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Handlers.Queries
{
    public class GetCandidateRequestHandler : IRequestHandler<GetCandidateRequest, CandidateDto>
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;

        public GetCandidateRequestHandler(ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CandidateDto> Handle(GetCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.Get(request.CandidateId);
            return _mapper.Map<CandidateDto>(candidate);
        }
    }
}
