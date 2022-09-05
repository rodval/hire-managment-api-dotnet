using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.CompanyEmployees.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.CompanyEmployees.Handler.Commands
{
    public class DeleteCompanyEmployeeCommandHandler : IRequestHandler<DeleteCompanyEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCompanyEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCompanyEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.CompanyEmployeeRepository.Get(request.Id);

            if (employee == null)
                throw new NotFoundException(nameof(employee), request.Id);

            await _unitOfWork.CompanyEmployeeRepository.Delete(employee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
