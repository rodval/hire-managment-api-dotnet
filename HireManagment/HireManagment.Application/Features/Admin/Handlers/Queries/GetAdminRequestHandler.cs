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
    public class GetAdminRequestHandler : IRequestHandler<GetAdminRequest, AdminDto>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetAdminRequestHandler(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<AdminDto> Handle(GetAdminRequest request, CancellationToken cancellationToken)
        {
            var admin = await _adminRepository.Get(request.AdminId);
            return _mapper.Map<AdminDto>(admin);
        }
    }
}
