using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.OpeningApplication;
using HireManagment.Application.Features.OpeningApplications.Handler.Command;
using HireManagment.Application.Responses;
using HireManagment.Domain.Utilities;
using HireManagment.Domain;
using HireManagment.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireManagment.Application.Profiles;
using Shouldly;
using HireManagment.Application.Features.OpeningApplications.Request.Command;

namespace HireManagment.Test.OpeningApplications.Command
{
    public class CreateOpeningApplicationRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateOpeningApplicationDto _applicationDto;
        private readonly CreateOpeningApplicationCommandHandler _handler;

        public CreateOpeningApplicationRequestHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateOpeningApplicationCommandHandler(_mockUow.Object, _mapper);

            _applicationDto = new CreateOpeningApplicationDto
            {
                DateApplication = DateTime.Now,
                Status = ApplicationStatusType.InProcess,
                CompanyEmployeeId = 1,
                CandidateId = 1
            };
        }

        [Fact]
        public async Task CreateApplicationTest()
        {
            var result = await _handler.Handle(new CreateOpeningApplicationCommand() { CreateOpeningApplication = _applicationDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(2);
        }
    }
}
