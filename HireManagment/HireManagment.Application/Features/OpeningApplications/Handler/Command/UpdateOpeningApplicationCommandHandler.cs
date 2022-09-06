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
    public class UpdateOpeningApplicationCommandHandler : IRequestHandler<UpdateOpeningApplicationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOpeningApplicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = await _unitOfWork.OpeningApplicationRepository.Get(request.OpeningApplication.Id);

            if (application is null)
                throw new NotFoundException(nameof(application), request.OpeningApplication.Id);

            _mapper.Map(request.OpeningApplication, application);

            await _unitOfWork.OpeningApplicationRepository.Update(application);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
