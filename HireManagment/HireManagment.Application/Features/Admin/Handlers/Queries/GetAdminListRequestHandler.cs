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
    internal class GetAdminListRequestHandler : IRequestHandler<GetAdminListRequest, List<AdminListDto>>
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetAdminListRequestHandler(IAdminRepository enrollmentRepository, IMapper mapper)
        {
            _adminRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminListDto>> Handle(GetAdminListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _adminRepository.GetAll();
            return _mapper.Map<List<AdminListDto>>(admin);
        }
    }
}
