using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.CompanyEmployee;
using HireManagment.Application.Features.Admins.Request.Queries;
using HireManagment.Application.Features.CompanyEmployees.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Handler.Queries
{
    public class GetCompanyEmployeeRequestHandler : IRequestHandler<GetCompanyEmployeeRequest, CompanyEmployeeDto>
    {
        private readonly ICompanyEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetCompanyEmployeeRequestHandler(ICompanyEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompanyEmployeeDto> Handle(GetCompanyEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _repository.Get(request.CompanyEmployeeId);
            return _mapper.Map<CompanyEmployeeDto>(employee);
        }
    }
}
