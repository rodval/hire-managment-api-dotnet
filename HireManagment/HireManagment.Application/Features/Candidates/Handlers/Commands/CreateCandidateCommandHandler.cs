using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Candidates.Request.Commands;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Candidates.Handlers.Commands
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCandidateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var candidate = _mapper.Map<Candidate>(request.CreateCandidate);

            candidate = await _unitOfWork.CandidateRepository.Add(candidate);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = candidate.Id;

            return response;
        }
    }
}
