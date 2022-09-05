using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.OpeningApplications.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Handler.Command
{
    public class DeleteOpeningApplicationCommandHandler : IRequestHandler<DeleteOpeningApplicationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOpeningApplicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.OpeningApplicationRepository.Get(request.Id);

            if (application == null)
                throw new NotFoundException(nameof(application), request.Id);

            await _unitOfWork.OpeningApplicationRepository.Delete(application);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
