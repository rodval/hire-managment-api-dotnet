using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Companies.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Companies.Handlers.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.Get(request.Id);

            if (company == null)
                throw new NotFoundException(nameof(company), request.Id);

            await _unitOfWork.CompanyRepository.Delete(company);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
