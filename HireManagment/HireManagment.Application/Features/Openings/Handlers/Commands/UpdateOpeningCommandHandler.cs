using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Openings.Request.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Handlers.Commands
{
    public class UpdateOpeningCommandHandler : IRequestHandler<UpdateOpeningCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOpeningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOpeningCommand request, CancellationToken cancellationToken)
        {
            var opening = await _unitOfWork.OpeningRepository.Get(request.Opening.Id);

            if (opening is null)
                throw new NotFoundException(nameof(opening), request.Opening.Id);

            _mapper.Map(request.Opening, opening);

            await _unitOfWork.OpeningRepository.Update(opening);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
