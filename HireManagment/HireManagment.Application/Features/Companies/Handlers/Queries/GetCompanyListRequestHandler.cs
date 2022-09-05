using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Company;
using HireManagment.Application.Features.Companies.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Companies.Handlers.Queries
{
    public class GetCompanyListRequestHandler : IRequestHandler<GetCompanyListRequest, List<CompanyListDto>>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyListRequestHandler(ICompanyRepository repository, IMapper mapper)
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
