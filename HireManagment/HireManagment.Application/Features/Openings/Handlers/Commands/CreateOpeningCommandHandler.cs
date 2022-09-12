using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Openings.Request.Command;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Openings.Handlers.Commands
{
    public class CreateOpeningCommandHandler : IRequestHandler<CreateOpeningCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOpeningCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateOpeningCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var opening = _mapper.Map<Opening>(request.CreateOpening);

            opening = await _unitOfWork.OpeningRepository.Add(opening);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = opening.Id.ToString();

            return response;
        }
    }
}
