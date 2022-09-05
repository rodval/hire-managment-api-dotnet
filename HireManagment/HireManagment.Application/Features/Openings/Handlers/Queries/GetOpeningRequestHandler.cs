using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Opening;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.Openings.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Handlers.Queries
{
    public class GetOpeningRequestHandler : IRequestHandler<GetOpeningRequest, OpeningDto>
    {
        private readonly IOpeningRepository _repository;
        private readonly IMapper _mapper;

        public GetOpeningRequestHandler(IOpeningRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OpeningDto> Handle(GetOpeningRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.Get(request.OpeningId);
            return _mapper.Map<OpeningDto>(opening);
        }
    }
}
