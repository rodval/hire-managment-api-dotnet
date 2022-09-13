using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Features.OpeningApplications.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Handler.Queries
{
    public class GetCandidatesaApplicationListRequestHandler : IRequestHandler<GetCandidatesaApplicationListRequest, List<OpeningApplicationListDto>>
    {
        private readonly IOpeningApplicationRepository _repository;
        private readonly IMapper _mapper;

        public GetCandidatesaApplicationListRequestHandler(IOpeningApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OpeningApplicationListDto>> Handle(GetCandidatesaApplicationListRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.GetCandidatesApplication(request.CandidateId);
            return _mapper.Map<List<OpeningApplicationListDto>>(opening);
        }
    }
}
