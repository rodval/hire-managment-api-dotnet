using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.Features.Admin.Request.Commands;
using HireManagment.Application.Responses;
using HireManagment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admin.Handlers.Commands
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, BaseCommandResponses>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();
            var admin = _mapper.Map<AdminApi>(request.CreateAdminApi);

            admin = await _unitOfWork.AdminRepository.Add(admin);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = admin.Id;

            return response;
        }
    }
}
