using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Handler.Commands
{
    internal class UpdateCompanyEmployeeCommandHandler: IRequestHandler<UpdateCompanyEmployeeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.CompanyEmployeeRepository.Get(request.Employee.Id);

            if (employee is null)
                throw new NotFoundException(nameof(employee), request.Employee.Id);

            _mapper.Map(request.Employee, employee);

            await _unitOfWork.CompanyEmployeeRepository.Update(employee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
