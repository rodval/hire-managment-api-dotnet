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
    public class GetOpeningListRequestHandler : IRequestHandler<GetOpeningListRequest, List<OpeningListDto>>
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public GetOpeningListRequestHandler(IAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OpeningListDto>> Handle(GetOpeningListRequest request, CancellationToken cancellationToken)
        {
            var opening = await _repository.GetAll();
            return _mapper.Map<List<OpeningListDto>>(opening);
        }
    }
}
