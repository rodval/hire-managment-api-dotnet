using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.OpeningApplications.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Handler.Queries
{
    public class GetOpeningApplicationListRequestHandler : IRequestHandler<GetOpeningApplicationListRequest, List<OpeningApplicationListDto>>
    {
        private readonly IOpeningApplicationRepository _repository;
        private readonly IMapper _mapper;

        public GetOpeningApplicationListRequestHandler(IOpeningApplicationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OpeningApplicationListDto>> Handle(GetOpeningApplicationListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAll();
            return _mapper.Map<List<OpeningApplicationListDto>>(admin);
        }
    }
}
