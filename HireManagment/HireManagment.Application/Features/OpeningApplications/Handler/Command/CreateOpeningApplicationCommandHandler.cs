using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.OpeningApplications.Request.Command;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.OpeningApplications.Handler.Command
{
    public class CreateOpeningApplicationCommandHandler : IRequestHandler<CreateOpeningApplicationCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOpeningApplicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateOpeningApplicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var application = _mapper.Map<OpeningApplication>(request.CreateOpeningApplication);

            application = await _unitOfWork.OpeningApplicationRepository.Add(application);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = application.Id.ToString();

            return response;
        }
    }
}
