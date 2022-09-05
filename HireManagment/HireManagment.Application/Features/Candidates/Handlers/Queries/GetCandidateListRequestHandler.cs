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
    public class GetCandidateListRequestHandler : IRequestHandler<GetCandidateListRequest, List<CandidateListDto>>
    {
        private readonly ICandidateRepository _repository;
        private readonly IMapper _mapper;

        public GetCandidateListRequestHandler(ICandidateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CandidateListDto>> Handle(GetCandidateListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAll();
            return _mapper.Map<List<CandidateListDto>>(admin);
        }
    }
}
