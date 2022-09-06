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
    public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, CompanyDto>
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyRequestHandler(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _repository.Get(request.CompanyId);
            return _mapper.Map<CompanyDto>(company);
        }
    }
}
