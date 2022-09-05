using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Candidates.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Handlers.Commands
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCandidateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _unitOfWork.CandidateRepository.Get(request.Id);

            if (candidate == null)
                throw new NotFoundException(nameof(candidate), request.Id);

            await _unitOfWork.CandidateRepository.Delete(candidate);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
