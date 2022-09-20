using AutoMapper;
using HireManagment.Application.Contracts.Persistence;
using HireManagment.Application.DTOs.Admin;
using HireManagment.Application.DTOs.Candidate;
using HireManagment.Application.Features.Admins.Handlers.Commands;
using HireManagment.Application.Features.Admins.Request.Commands;
using HireManagment.Application.Features.Candidates.Handlers.Commands;
using HireManagment.Application.Features.Candidates.Request.Commands;
using HireManagment.Application.Profiles;
using HireManagment.Application.Responses;
using HireManagment.Test.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireManagment.Test.Admin.Command
{
    public class CreateAdminCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateAdminApiDto _adminDto;
        private readonly CreateAdminCommandHandler _handler;

        public CreateAdminCommandHandlerTest()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateAdminCommandHandler(_mockUow.Object, _mapper);

            _adminDto = new CreateAdminApiDto
            {
                FirstName = "Robert",
                LastName = "Wade",
                Age = 32,
                Email = "rodrigovalladares1@gmail.com",
                Password = "P@ssword1"
            };
        }

        [Fact]
        public async Task CreateCandidateTest()
        {
            var result = await _handler.Handle(new CreateAdminCommand() { CreateAdminApi = _adminDto }, CancellationToken.None);

            var admins = await _mockUow.Object.AdminRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponses>();

            admins.Count.ShouldBe(3);
        }
    }
}
