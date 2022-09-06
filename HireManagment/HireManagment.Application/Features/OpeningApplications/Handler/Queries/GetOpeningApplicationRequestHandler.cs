using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
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
    public class GetOpeningApplicationRequestHandler : IRequestHandler<GetOpeningApplicationRequest, OpeningApplicationDto>
    {
        private readonly IOpeningApplicationRepository _repository;
        private readonly IMapper _mapper;

        public GetOpeningApplicationRequestHandler(IOpeningApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OpeningApplicationDto> Handle(GetOpeningApplicationRequest request, CancellationToken cancellationToken)
        {
            var application = await _repository.Get(request.OpeningApplicationId);
            return _mapper.Map<OpeningApplicationDto>(application);
        }
    }
}
