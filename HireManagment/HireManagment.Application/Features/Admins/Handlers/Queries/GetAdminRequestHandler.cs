using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Features.Admins.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admins.Handlers.Queries
{
    public class GetAdminRequestHandler : IRequestHandler<GetAdminRequest, AdminApiDto>
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public GetAdminRequestHandler(IAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdminApiDto> Handle(GetAdminRequest request, CancellationToken cancellationToken)
        {
            var admin = await _repository.Get(request.AdminId);
            return _mapper.Map<AdminApiDto>(admin);
        }
    }
}
