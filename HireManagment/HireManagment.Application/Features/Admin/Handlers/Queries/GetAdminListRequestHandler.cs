using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Features.Admin.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admin.Handlers.Queries
{
    public class GetAdminListRequestHandler : IRequestHandler<GetAdminListRequest, List<AdminApiListDto>>
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public GetAdminListRequestHandler(IAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AdminApiListDto>> Handle(GetAdminListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.GetAll();
            return _mapper.Map<List<AdminApiListDto>>(admin);
        }
    }
}
