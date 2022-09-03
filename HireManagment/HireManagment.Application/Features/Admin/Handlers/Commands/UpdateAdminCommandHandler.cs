using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.Exceptions;
using HireManagment.Application.Features.Admin.Request.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Application.Features.Admin.Handlers.Commands
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdminCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.Get(request.AdminApi.Id);

            if (admin is null)
                throw new NotFoundException(nameof(admin), request.AdminApi.Id);

            _mapper.Map(request.AdminApi, admin);

            await _unitOfWork.AdminRepository.Update(admin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
