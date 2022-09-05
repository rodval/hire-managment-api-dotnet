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
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.Get(request.Company.Id);

            if (company is null)
                throw new NotFoundException(nameof(company), request.Company.Id);

            _mapper.Map(request.Company, company);

            await _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
