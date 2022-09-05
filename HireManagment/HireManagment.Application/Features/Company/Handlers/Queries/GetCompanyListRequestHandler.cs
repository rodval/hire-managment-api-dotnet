using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Admin.Request.Queries;
using HireManagment.Application.Features.Company.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Company.Handlers.Queries
{
    public class GetCompanyListRequestHandler : IRequestHandler<GetCompanyListRequest, List<CompanyListDto>>
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyListRequestHandler(IAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CompanyListDto>> Handle(GetCompanyListRequest request, CancellationToken cancellationToken)
        {
            var companies = await _repository.GetAll();
            return _mapper.Map<List<CompanyListDto>>(companies);
        }
    }
}
