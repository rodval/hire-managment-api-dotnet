using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Handler.Commands
{
    public class CreateCompanyEmployeeCommandHandler : IRequestHandler<CreateCompanyEmployeeCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var employee = _mapper.Map<CompanyEmployee>(request.CreateEmployee);

            employee = await _unitOfWork.CompanyEmployeeRepository.Add(employee);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = employee.Id;

            return response;
        }
    }
}
