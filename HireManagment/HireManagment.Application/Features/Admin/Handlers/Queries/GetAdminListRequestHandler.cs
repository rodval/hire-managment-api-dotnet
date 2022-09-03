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
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public GetAdminListRequestHandler(IAdminRepository enrollmentRepository, IMapper mapper)
        {
            _adminRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminApiListDto>> Handle(GetAdminListRequest request, CancellationToken cancellationToken)
        {
            var admin = await _adminRepository.GetAll();
            return _mapper.Map<List<AdminApiListDto>>(admin);
        }
    }
}
