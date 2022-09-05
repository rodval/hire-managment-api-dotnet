using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.CompanyEmployees.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Handler.Queries
{
    public class GetCompanyEmployeeListRequestHandler : IRequestHandler<GetCompanyEmployeeListRequest, List<CompanyEmployeeListDto>>
    {
        private readonly ICompanyEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyEmployeeListRequestHandler(ICompanyEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CompanyEmployeeListDto>> Handle(GetCompanyEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetAll();
            return _mapper.Map<List<CompanyEmployeeListDto>>(employee);
        }
    }
}
