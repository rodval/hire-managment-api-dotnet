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
    public class DeleteOpeningCommandHandler : IRequestHandler<DeleteOpeningCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOpeningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOpeningCommand request, CancellationToken cancellationToken)
        {
            var opening = await _unitOfWork.OpeningRepository.Get(request.Id);

            if (opening == null)
                throw new NotFoundException(nameof(opening), request.Id);

            await _unitOfWork.OpeningRepository.Delete(opening);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
